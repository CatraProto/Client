using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections
{
    class MessagesHandler : IDisposable
    {
        public int OutgoingCount
        {
            get => OutgoingMessages.Reader.Count;
        }
        
        public Channel<MessageContainer> OutgoingMessages { get; } = Channel.CreateUnbounded<MessageContainer>();
        private readonly ILogger _logger;
        private MessageContainer _oldMessage;
        private ConcurrentDictionary<long, MessageContainer> _sentMessages = new ConcurrentDictionary<long, MessageContainer>();
        private AsyncLock _unencryptedMessagesLock = new AsyncLock();

        public MessagesHandler(ILogger logger)
        {
            _logger = logger.ForContext<MessagesHandler>();
        }

        public async Task<Task> EnqueueMessage(OutgoingMessage message, IRpcMessage rpcContainer)
        {
            var completionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var messageContainer = new MessageContainer
            {
                OutgoingMessage = message,
                CompletionSource = completionSource,
                RpcContainer = rpcContainer
            };

            if (!message.IsEncrypted)
            {
                //This deserves an explanation:
                //UnencryptedMessages aren't identifiable by their message id since it is not persistent,
                //therefore, the best way to complete the correct task is to send one message after the previous one received a response
                _logger.Information("Enqueuing unencrypted message, acquiring lock...");
                using (await _unencryptedMessagesLock.LockAsync())
                {
                    _logger.Information("Lock acquired for unencrypted message");
                    if (_oldMessage != null)
                    {
                        _logger.Information("An old unencrypted message hasn't yet received a response, waiting before enqueueing this one...");
                        try
                        {
                            await _oldMessage.CompletionSource.Task;
                        }
                        finally
                        {
                            if (!_oldMessage.CompletionSource.Task.IsCompletedSuccessfully)
                            {
                                _logger.Information("The old message got cancelled, proceeding to enqueue...");
                            } 
                        }
                    }

                    _oldMessage = messageContainer;
                }
            }

            if (message.CancellationToken.IsCancellationRequested)
            {
                //This is because the registration doesn't get called if the token is already cancelled
                _logger.Information(
                    "Cancellation of the message got requested just before registering a callback, cancelling...");
                DequeueMessage(messageContainer, message.CancellationToken);
                return Task.FromCanceled(message.CancellationToken);
            }

            messageContainer.CancellationTokenRegistration =
                message.CancellationToken.Register(() => DequeueMessage(messageContainer, message.CancellationToken));
            OutgoingMessages.Writer.TryWrite(messageContainer);
            _logger.Information("{Type} message enqueued successfully", message.IsEncrypted ? "Encrypted" : "Unencrypted");
            if (message.MessageOptions.AwaiterType == AwaiterType.WhenScheduled)
            {
                completionSource.TrySetResult();
            }

            return completionSource.Task;
        }

        public void DequeueMessage(MessageContainer message, CancellationToken? token = null)
        {
            _logger.Information(
                "Dequeuing message {Message}, IsEncrypted: {Encrypted}, CancellationRequested: {Requested}",
                message.OutgoingMessage.Body, message.OutgoingMessage.IsEncrypted, token != null);
            message.CancellationTokenRegistration.Unregister();
            if (token != null)
            {
                message.CompletionSource.TrySetCanceled(token.Value);
            }
            else
            {
                message.CompletionSource.TrySetCanceled();
            }

            var messageKey = _sentMessages.FirstOrDefault(x => x.Value == message).Key;
            _sentMessages.TryRemove(messageKey, out _);
        }

        public bool SetMessageResult(long messageId, object response)
        {
            MessageContainer container;
            if (messageId != 0)
            {
                _sentMessages.TryRemove(messageId, out container);
            }
            else
            {
                container = _oldMessage;
            }

            if (container != null)
            {
                container.RpcContainer.SetResponse(response);
                container.CancellationTokenRegistration.Unregister();
                container.CompletionSource.TrySetResult();
                _logger.Information("Received a message of type {Type} in reply to message {Id}", response, messageId);
            }
            else
            {
                _logger.Warning("Received a message of type {Type} but no message with id {Id} could be found", response, messageId);
                return false;
            }

            return true;
        }
        
        public bool AddSentMessage(long messageId, MessageContainer message)
        {
            return _sentMessages.TryAdd(messageId, message);
        }

        public bool RemoveSentMessage(long messageId, out MessageContainer message)
        {
            return _sentMessages.TryRemove(messageId, out message);
        }

        public bool GetMethod(long messageId, out IMethod method)
        {
            if (messageId == 0)
            {
                if (_oldMessage != null)
                {
                    method = _oldMessage.OutgoingMessage.Body as IMethod;
                    return true;
                }

                method = null;
                return false;
            }

            if (_sentMessages.TryGetValue(messageId, out var container))
            {
                if (container.OutgoingMessage.Body is IMethod outMethod)
                {
                    method = outMethod;
                    return true;
                }
                else
                {
                    _logger.Error("Found message {Id} but it is not a method", messageId);
                }
            }
            else
            {
                _logger.Error("Couldn't find messageId in the list of sent messages {Id}", messageId);
            }

            method = null;
            return false;
        }

        public void Dispose()
        {
            _unencryptedMessagesLock?.Dispose();
        }
    }
}