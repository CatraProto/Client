using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Exceptions;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.Extensions;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using Serilog;
using IMessage = CatraProto.Client.Connections.Messages.Interfaces.IMessage;

namespace CatraProto.Client.Connections.Loop
{
    class ReadLoop : Async.Loops.Loop
    {
        private readonly CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private ConnectionState _connectionState; 
        private Connection _connection;
        private ILogger _logger;

        public ReadLoop(Connection connection, ILogger logger)
        {
            _logger = logger.ForContext<ReadLoop>();
            _connection = connection;
            _connectionState = connection.ConnectionState;
        }

        private async Task Loop()
        {
            var protocol = _connection.Protocol;
            _logger.Information("Listening for incoming messages from {Connection}...", _connection.ConnectionInfo);
            while (!_cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var message = await protocol.Reader.ReadMessageAsync(_cancellationToken.Token);
                    _connection.Signaler.SetSignal(false);
                    using var reader = new Reader(MergedProvider.Singleton, message.ToMemoryStream());

                    switch (message.Length)
                    {
                        case 0:
                            _logger.Error("Received 0 bytes from server");
                            continue;
                        case 4:
                            _connectionState.MessagesDispatcher.DispatchMessage(new UnencryptedMessage { Body = message });
                            _connection.Signaler.SetSignal(true);
                            continue;
                    }

                    var authKeyId = reader.Read<long>();
                    IMessage imported;
                    if (authKeyId == 0)
                    {
                        imported = new UnencryptedMessage(message);
                    }
                    else
                    {
                        var getAuthKey = await _connection.ConnectionState.TemporaryAuthKey.GetAuthKeyAsync(forceReturn: true);
                        if (authKeyId == getAuthKey.AuthKeyId)
                        {
                            imported = new EncryptedMessage(getAuthKey, message);
                        }
                        else
                        {
                            _logger.Error("Received a message from an unknown AuthKeyId ({Id})", authKeyId);
                            continue;
                        }
                    }

                    _connectionState.MessagesDispatcher.DispatchMessage(imported);
                }
                catch (OperationCanceledException e) when (e.CancellationToken == _cancellationToken.Token)
                {
                    //Ignored on purpose
                }
                catch (ConnectionClosedException)
                {
                    _ = _connection.ConnectAsync();
                    break;
                }
                catch (System.IO.IOException e)
                {
                    _ = _connection.ConnectAsync();
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

        protected override void StopSignal()
        {
            _cancellationToken.Cancel();
        }

        protected override Task StartSignal()
        {
            _ = Loop();
            return Task.CompletedTask;
        }
    }
}