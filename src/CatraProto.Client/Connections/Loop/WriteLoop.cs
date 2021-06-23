using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class WriteLoop : Async.Loops.Loop
    {
        private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private Connection _connection;
        private ILogger _logger;
        private MessagesHandler _messagesHandler;

        public WriteLoop(Connection connection, MessagesHandler messagesHandler, ILogger logger)
        {
            _connection = connection;
            _messagesHandler = messagesHandler;
            _logger = logger.ForContext<WriteLoop>();
        }

        private async Task Loop()
        {
            _logger.Information("Listening for outgoing messages...");
            while (!_cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var container = await _messagesHandler.ListenAsync(_cancellationToken.Token);
                    var message = container.OutgoingMessage;
                    if (message.CancellationToken.IsCancellationRequested)
                    {
                        _logger.Information("Ignoring message because cancellation is requested");
                        continue;
                    }

                    IMessage preparedMessage = null;
                    if (message.IsEncrypted)
                    {
                    }
                    else
                    {
                        _logger.Information("Serializing unencrypted message of type {MessageType}", message.Body);
                        preparedMessage = new UnencryptedMessage
                        {
                            Body = message.Body.ToArray(MergedProvider.Singleton),
                            MessageId = _connection.MessageIdsHandler.ComputeMessageId()
                        };
                        var exported = preparedMessage!.Export();
                        await _connection.Protocol.Writer.SendAsync(exported);
                        _logger.Information("Message sent");
                    }

                    //_logger.Information("Sending message with Id {Id} as unencryptedMessage, length {Length}", message.MessageId /*, message.Length*/);
                }
                catch (OperationCanceledException)
                {
                    //Ignored: Cancellation token.
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Unexpected exception thrown, please report this on the github issues page");
                }
            }

            _logger.Information("WriteLoop shut down");
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