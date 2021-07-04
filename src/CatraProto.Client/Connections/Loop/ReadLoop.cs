using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.Extensions;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class ReadLoop : Async.Loops.Loop
    {
        private readonly CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private readonly Connection _connection;
        private ILogger _logger;

        public ReadLoop(Connection connection, ILogger logger)
        {
            _logger = logger.ForContext<ReadLoop>();
            _connection = connection;
        }

        private async Task Loop()
        {
            _logger.Information("Listening for incoming messages from {Connection}...", _connection.ConnectionInfo);
            var protocol = _connection.Protocol;
            while (!_cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var message = await protocol.Reader.ReadMessageAsync(_cancellationToken.Token);
                    using var reader = new Reader(MergedProvider.Singleton, message.ToMemoryStream());
                    if (message.Length == 0)
                    {
                        _logger.Error("Received 0 bytes from server");
                        continue;
                    }
                    
                    if (message.Length == 4)
                    {
                        _connection.MessagesDispatcher.DispatchMessage(new UnencryptedMessage
                        {
                            Body = message
                        });
                        continue;
                    }

                    var authKey = reader.Read<long>();
                    if (authKey == 0)
                    {
                        var imported = new UnencryptedMessage(message);
                        _logger.Information(
                            "Received an unencrypted message from Telegram, dispatching... Id: {MessageId}, Body Length: {Length}",
                            imported.MessageId, imported.Body.Length);
                        _connection.MessagesDispatcher.DispatchMessage(imported);
                    }
                    else
                    {
                        var imported = new EncryptedMessage(_connection.SessionData.AuthKey, message);
                        _logger.Information(
                            "Received an encrypted message from Telegram, dispatching... Id: {MessageId}, Body Length: {Length}",
                            imported.MessageId, imported.Body.Length);
                        _connection.MessagesDispatcher.DispatchMessage(imported);
                    }
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Unexpected exception thrown");
                }
            }

            _logger.Information("ReadLoop shutdown");
            SetLoopStopped();
        }

        protected override void StopSignal()
        {
            _logger.Information("Requesting ReadLoop shutdown");
            _cancellationToken.Cancel();
        }

        protected override Task StartSignal()
        {
            _ = Loop();
            return Task.CompletedTask;
        }
    }
}