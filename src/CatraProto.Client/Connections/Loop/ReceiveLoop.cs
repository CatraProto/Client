using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Enums.Resumable;
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
                            _logger.Information("Send loop started for connection {Connection}", _connection.ConnectionInfo);
                            break;
                        case GenericSignalState.Stop:
                            _logger.Information("Send loop stopped for connection {Connection}", _connection.ConnectionInfo);
                            SetSignalHandled(GenericLoopState.Stopped, currentState);
                            return;
                    }
                }
                try
                {
                    var message = await _connection.Protocol.Reader.ReadMessageAsync(cancellationToken);
                    //_connection.Signaler.SetSignal(false);
                    using var reader = new Reader(MergedProvider.Singleton, message.ToMemoryStream());

                    if (message.Length == 4)
                    {
                        await _messagesDispatcher.DispatchMessage(new UnencryptedConnectionMessage(message));
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

                    await _messagesDispatcher.DispatchMessage(imported);
                }
                catch (OperationCanceledException e) when (e.CancellationToken == cancellationToken)
                {
                    //Ignored on purpose
                }
                catch (IOException e)
                {
                    _logger.Error("IOException received. Message: \"{Info}\", reconnecting...", e.Message);
                    _ = _connection.ConnectAsync(cancellationToken);
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Exception thrown on ReceiveLoop for {Info}", _connection.ConnectionInfo);
                    break;
                }
            }
        }

        public override string ToString() => $"Read loop for connection {_connection}";
    }
}