using System;
using System.IO;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Connections.Exceptions;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.Extensions;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class ReceiveLoop : GenericLoop
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
            Task.Run(Loop);
        }

        private async Task Loop()
        {
            _logger.Information("Listening for incoming messages from {Connection}...", _connection.ConnectionInfo);
            while (true)
            {
                if (StateSignaler.GetCurrentState() != SignalState.Start)
                {
                    await StateSignaler.WaitAsync();
                }

                var protocol = _connection.Protocol!;
                var shutdownToken = GetShutdownToken();
                try
                {
                    var message = await protocol.Reader!.ReadMessageAsync(shutdownToken);
                    _connection.Signaler.SetSignal(false);
                    using var reader = new Reader(MergedProvider.Singleton, message.ToMemoryStream());

                    switch (message.Length)
                    {
                        case 0:
                            _logger.Error("Received 0 bytes from server");
                            continue;
                        case 4:
                            _messagesDispatcher.DispatchMessage(new UnencryptedConnectionMessage(message));
                            _connection.Signaler.SetSignal(true);
                            continue;
                    }

                    var authKeyId = reader.Read<long>();
                    IConnectionMessage imported;
                    if (authKeyId == 0)
                    {
                        imported = new UnencryptedConnectionMessage(message);
                    }
                    else
                    {
                        var getAuthKey = await _mtProtoState.KeysHandler.TemporaryAuthKey.GetAuthKeyAsync(forceReturn: true, token: shutdownToken);
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
                catch (OperationCanceledException e) when (e.CancellationToken == shutdownToken)
                {
                    //Ignored on purpose
                }
                catch (ConnectionClosedException)
                {
                    _ = _connection.ConnectAsync(shutdownToken);
                    break;
                }
                catch (IOException)
                {
                    _ = _connection.ConnectAsync(shutdownToken);
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Exception thrown on ReadLoop for {Info}", _connection.ConnectionInfo);
                    break;
                }

                _connection.Signaler.SetSignal(true);
            }

            _logger.Information("ReadLoop for connection {Info} shutdown", _connection.ConnectionInfo);
            SetLoopStopped();
        }
    }
}