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
    class ReceiveLoop : LoopImplementation<GenericLoopState, GenericSignalState>
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
                            _logger.Information("Receive loop started for connection {Connection}", _connection.ConnectionInfo);
                            break;
                        case GenericSignalState.Stop:
                            _logger.Information("Receive loop stopped for connection {Connection}", _connection.ConnectionInfo);
                            SetSignalHandled(GenericLoopState.Stopped, currentState);
                            return;
                    }
                }

                try
                {
                    var message = await _connection.Protocol.Reader.ReadMessageAsync(cancellationToken);
                    using var reader = new Reader(MergedProvider.Singleton, message.ToMemoryStream());

                    if(message.Length < 4)
                    {
                        _logger.Warning("Ignoring payload {Payload} because length is less than 4", message);
                        continue;
                    }

                    if (message.Length == 4)
                    {
                        _messagesDispatcher.DispatchMessage(new UnencryptedConnectionMessage(message));
                        continue;
                    }

                    //8 + 16 + 8 + 8 + 8 + 4 + 4
                    if (message.Length < 56)
                    {
                        _logger.Warning("Ignoring payload {Payload} because length is less than 56", message);
                        continue;
                    }


                    var authKeyId = reader.ReadInt64().Value;
                    IConnectionMessage imported;
                    if (authKeyId == 0)
                    {
                        imported = new UnencryptedConnectionMessage(message);
                    }
                    else
                    {
                        var getAuthKey = _mtProtoState.KeysHandler.TemporaryAuthKey.GetCachedKey();
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

                    _messagesDispatcher.DispatchMessage(imported);
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
                    _logger.Error(e, "Exception thrown on ReceiveLoop for {Info}", _connection.ConnectionInfo);
                }
            }
        }

        public override string ToString() => $"Receive loop for connection {_connection}";
    }
}