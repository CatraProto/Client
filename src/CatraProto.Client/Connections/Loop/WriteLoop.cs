using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.MTProto.AuthKeyHandler;
using CatraProto.Client.MTProto.AuthKeyHandler.Results;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;
using Serilog;
using EncryptedMessage = CatraProto.Client.Connections.Messages.EncryptedMessage;

namespace CatraProto.Client.Connections.Loop
{
    class WriteLoop : Async.Loops.Loop
    {
        private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private Connection _connection;
        private ILogger _logger;
        private MessagesHandler _messagesHandler;
        
        public WriteLoop(Connection connection, ILogger logger)
        {
            _connection = connection;
            _messagesHandler = connection.MessagesHandler;
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

                    try
                    {
                        _logger.Information("Serializing message of type {Type}", message.Body);
                        var body = message.Body.ToArray(MergedProvider.Singleton);
                        IMessage preparedMessage;
                        if (message.IsEncrypted)
                        {
                            preparedMessage = new EncryptedMessage(_connection.SessionData.AuthKey)
                            {
                                AuthKeyId = _connection.SessionData.AuthKey.AuthKeyId,
                                Salt = _connection.SessionData.Salt,
                                SessionId = _connection.SessionData.SessionId,
                                MessageId = _connection.MessageIdsHandler.ComputeMessageId(),
                                SeqNo = _connection.SessionData.SeqnoHandler.ComputeSeqno(message.Body),
                                Body = body
                            };
                        }
                        else
                        {
                            preparedMessage = new UnencryptedMessage
                            {
                                Body = body,
                                MessageId = _connection.MessageIdsHandler.ComputeMessageId()
                            };
                        }
                        
                        var exported = preparedMessage.Export();
                        await _connection.Protocol.Writer.SendAsync(exported);
                        if (message.IsEncrypted)
                        {
                            _connection.MessagesHandler.AddSentMessage(preparedMessage.MessageId, container);
                        }
                    }
                    catch (SerializationException e)
                    {
                        _logger.Error("Serialization of message of type {Type} failed, throwing exception on caller", message.Body);
                        container.CompletionSource.TrySetException(e);
                    }
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