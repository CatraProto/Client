/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    internal class ReceiveLoop : LoopImplementation<GenericLoopState, GenericSignalState>
    {
        private readonly MessagesDispatcher _messagesDispatcher;
        private readonly MTProtoState _mtProtoState;
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public ReceiveLoop(Connection connection, ILogger logger)
        {
            _logger = logger.ForContext<ReceiveLoop>();
            _connection = connection;
            _messagesDispatcher = connection.MessagesDispatcher;
            _mtProtoState = connection.MtProtoState;
        }

        public override async Task LoopAsync(CancellationToken cancellationToken)
        {
            var currentState = StateSignaler.GetCurrentState(true);
            while (true)
            {
                if (currentState!.AlreadyHandled)
                {
                    currentState = StateSignaler.GetCurrentState(true);
                }

                if (!currentState!.AlreadyHandled)
                {
                    switch (currentState.Signal)
                    {
                        case GenericSignalState.Start:
                            SetSignalHandled(GenericLoopState.Running, currentState);
                            _logger.Information("Receive loop started");
                            break;
                        case GenericSignalState.Stop:
                            _logger.Information("Receive loop stopped");
                            SetSignalHandled(GenericLoopState.Stopped, currentState);
                            return;
                    }
                }

                try
                {
                    // Already disposed when disposing reader
                    var message = await _connection.Protocol.Reader.ReadMessageAsync(cancellationToken);
                    using var reader = new Reader(MergedProvider.Singleton, message);

                    if (message.Length < 4)
                    {
                        _logger.Warning("Ignoring payload {Payload} because length is less than 4", message);
                        continue;
                    }

                    if (message.Length == 4)
                    {
                        _messagesDispatcher.DispatchMessage(new UnencryptedConnectionMessage(message), true);
                        continue;
                    }

                    //8 + 16 + 8 + 8 + 8 + 4 + 4
                    if (message.Length < 56)
                    {
                        _logger.Warning("Ignoring payload {Payload} because length is less than 56", message);
                        continue;
                    }


                    var authKeyId = reader.ReadInt64().Value;
                    message.Seek(0, SeekOrigin.Begin);
                    IConnectionMessage imported;
                    if (authKeyId == 0)
                    {
                        imported = new UnencryptedConnectionMessage(message);
                    }
                    else
                    {
                        var getAuthKey = _mtProtoState.KeyManager!.TemporaryAuthKey.GetCachedKey();
                        if (authKeyId == getAuthKey.AuthKeyId)
                        {
                            imported = new EncryptedConnectionMessage(getAuthKey, message);
                        }
                        else
                        {
                            _logger.Error("Received a message from an unknown AuthKeyId ({Id})", authKeyId);
                            continue;
                        }
                    }

                    _messagesDispatcher.DispatchMessage(imported, false);
                    imported.Dispose();
                }
                catch (OperationCanceledException e) when (e.CancellationToken == cancellationToken)
                {
                    _logger.Information("{Loop} stopped after cancellation token threw exception", ToString());
                    SetLoopState(GenericLoopState.Stopped);
                    return;
                }
                catch (IOException e)
                {
                    _logger.Error("IOException received. Message: \"{Info}\", reconnecting...", e.Message);
                    _ = _connection.ConnectAsync();
                    SetLoopState(GenericLoopState.Stopped);
                    return;
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Exception thrown on ReceiveLoop");
                }
            }
        }

        public override string ToString()
        {
            return $"Receive loop";
        }
    }
}