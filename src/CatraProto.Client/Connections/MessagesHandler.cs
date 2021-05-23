using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections
{
    internal class MessagesHandler : IDisposable
    {
        public int OutgoingCount
        {
            get => _completions.Count;
        }

        private ConcurrentDictionary<long, MessageContainer> _sentMessages = new ConcurrentDictionary<long, MessageContainer>();
        private ConcurrentDictionary<OutgoingMessage, MessageContainer> _completions = new ConcurrentDictionary<OutgoingMessage, MessageContainer>();
        private Channel<OutgoingMessage> _outgoingMessages = Channel.CreateUnbounded<OutgoingMessage>();
        private AsyncLock _unencryptedMessagesLock = new AsyncLock();
        private MessageContainer _oldMessage;
        private readonly ILogger _logger;


        public MessagesHandler(ILogger logger)
        {
            _logger = logger.ForContext<MessagesHandler>();
        }

        public async Task<OutgoingMessage> Listen(CancellationToken cancellationToken)
        {
            var message = await _outgoingMessages.Reader.ReadAsync(cancellationToken);

            //This is because channels don't allow to remove items, I'll probably work on a better implementation in the future
            //so that I can avoid using them.
            if (message.CancellationToken.IsCancellationRequested)
            {
                _logger.Information("Cancellation of the message is requested, picking another item...");
                return await Listen(cancellationToken);
            }

            return message;
        }

        public async Task<Task> EnqueueMessage(OutgoingMessage message, IRpcMessage rpcContainer)
        {
            _logger.Information("Enqueueing message, encrypted: {Encrypted}", message.IsEncrypted);
            var completionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var messageContainer = new MessageContainer
            {
                OutgoingMessage = message,
                CompletionSource = completionSource,
                RpcContainer = rpcContainer
            };

            if (message.IsEncrypted)
            {
                if (!_completions.TryAdd(message, messageContainer))
                {
                    _logger.Warning("Encrypted message was already queued, throwing...");
                    throw new InvalidOperationException("Can't schedule the same message several times");
                }
            }
            else
            {
                //This deserves an explanation.
                //UnencryptedMessages aren't identifiable by their MessageId since it is not persistent,
                //therefore, the best way to complete the correct task is to send one message after the previous one received a response
                _logger.Information("Acquiring lock for unencrypted message");
                using (await _unencryptedMessagesLock.LockAsync())
                {
                    _logger.Information("Lock acquired for unencrypted message");
                    if (_oldMessage != null)
                    {
                        _logger.Information("An old unencrypted message hasn't yet received a response, waiting before queueing");
                        try
                        {
                            await _oldMessage.CompletionSource.Task;
                        }
                        catch (OperationCanceledException)
                        {
                            _logger.Information("Old unencrypted task was cancelled while waiting, this is not an error but it's worth logging");
                        }
                    }

                    _outgoingMessages.Writer.TryWrite(message);
                    _oldMessage = messageContainer;
                    _logger.Information("Unencrypted enqueued successfully");
                }
            }

            //I'm not sure if it's going to happen, but I want to prevent having DequeueMessage called while we are still scheduling
            messageContainer.CancellationTokenRegistration = message.CancellationToken.Register(() => DequeueMessage(message));
            _outgoingMessages.Writer.TryWrite(message);

            _logger.Information("Message successfully enqueued");
            return completionSource.Task;
        }

        public void DequeueMessage(OutgoingMessage message)
        {
            if (message.IsEncrypted)
            {
                _logger.Information("Dequeuing encrypted message");
                if (_completions.TryRemove(message, out var container))
                {
                    container.CompletionSource.TrySetCanceled();
                }
            }
            else
            {
                _logger.Information("Dequeuing unencrypted message");
                if (_completions.TryRemove(message, out var container))
                {
                    container.CompletionSource.TrySetCanceled();
                    container.CancellationTokenRegistration.Unregister();
                }
            }
        }

        public void CompleteMessage(IncomingMessage message)
        {
            if (message.IsEncrypted)
            {
                if (message.Body is RpcResult result)
                {
                    if (_sentMessages.TryGetValue(result.ReqMsgId, out var container))
                    {
                        container.CompletionSource.TrySetResult();
                        container.CancellationTokenRegistration.Unregister();
                    }
                    else
                    {
                        _logger.Warning("Message id {Id} not found while trying to complete", result.ReqMsgId);
                    }
                }
                else
                {
                    _logger.Warning("Trying to complete an encrypted message which is not RpcResult");
                }
            }
            else
            {
                if (_oldMessage != null)
                {
                    _oldMessage.CompletionSource.TrySetResult();
                    _oldMessage.RpcContainer.SetResponse(message.Body);
                    _oldMessage.CancellationTokenRegistration.Unregister();
                    _logger.Information("Completed task for unencryptedMessage, received: {Type}", message.Body.ToString());
                }
                else
                {
                    _logger.Warning("Received unencryptedMessage to complete but not message was set, received type: {Type}", message.Body.ToString());
                }
            }
        }

        public bool AddSentMessage(long messageId, MessageContainer message)
        {
            return _sentMessages.TryAdd(messageId, message);
        }

        public bool GetMessageMethod(long messageId, out IMethod method)
        {
            if (_sentMessages.TryGetValue(messageId, out var container))
            {
                if (container.OutgoingMessage.Body is IMethod outMethod)
                {
                    method = outMethod;
                    return true;
                }
                else
                {
                    _logger.Warning("Requested messageId {Id} is not a method", messageId);
                }
            }
            else
            {
                _logger.Warning("Couldn't find messageId {Id}", messageId);
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