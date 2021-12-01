using System;
using System.IO;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    //TODO Loop implementation
    class ReceiveLoopController : GenericLoopController
    {
        private readonly MessagesDispatcher _messagesDispatcher;
        private readonly MTProtoState _mtProtoState;
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public ReceiveLoopController(Connection connection, ILogger logger) : base(logger)
        {
            _logger = logger.ForContext<ReceiveLoopController>();
            _connection = connection;
            _messagesDispatcher = connection.MessagesDispatcher;
            _mtProtoState = connection.MtProtoState;
            Task.Run(Loop);
        }

        private async Task Loop()
        {
            /*while (true)
            {
                try
                {
                    //if (StateSignaler.GetCurrentState(true) == SignalState.Stop)
                    {
                        _logger.Information("ReceiveLoop for connection {Info} shutdown", _connection.ConnectionInfo);
                        SetLoopState(LoopState.Stopped);

                        //await StateSignaler.WaitStateAsync(false, default, SignalState.Start);
                        _logger.Information("Listening for incoming messages on connection {Info}...", _connection.ConnectionInfo);
                    }
                }
                catch (ObjectDisposedException e) when (e.ObjectName == "AsyncStateSignaler")
                {
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Exception thrown on SendLoop for {Info}", _connection.ConnectionInfo);
                }

                var protocol = _connection.Protocol!;
                //var shutdownToken = GetShutdownToken();
                try
                {
                    var message = await protocol.Reader!.ReadMessageAsync(shutdownToken);
                    //_connection.Signaler.SetSignal(false);
                    using var reader = new Reader(MergedProvider.Singleton, message.ToMemoryStream());

                    if (message.Length == 4)
                    {
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
                catch (IOException e)
                {
                    _logger.Error("IOException received. Message: \"{Info}\", reconnecting...", e.Message);
                    _ = _connection.ConnectAsync(shutdownToken);
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Exception thrown on ReceiveLoop for {Info}", _connection.ConnectionInfo);
                    break;
                }
                finally
                {
                    _connection.Signaler.SetSignal(true);
                }
            }

            _logger.Information("Dispose ReceiveLoop for connection {Info}", _connection.ConnectionInfo);
            SetLoopStopped();*/
        }
    }
}