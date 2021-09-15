using System;
using System.Threading;
using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling.Items
{
    class MessageItem
    {
        public MessageSendingOptions MessageSendingOptions { get; }
        public CancellationToken CancellationToken { get; }
        public IObject Body { get; }
        
        private readonly object _mutex = new object();
        private readonly MessageStatus _messageStatus;
        private MessagesHandler? _messagesHandler;
        private readonly ILogger _logger;

        public MessageItem(IObject body, MessageSendingOptions messageSendingOptions, MessageStatus messageStatus, ILogger logger, CancellationToken cancellationToken)
        {
            MessageSendingOptions = messageSendingOptions;
            _logger = logger.ForContext<MessageItem>();
            CancellationToken = cancellationToken;
            _messageStatus = messageStatus;
            Body = body;
            
            if (cancellationToken.CanBeCanceled)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    SetCanceled(cancellationToken);
                }
                
                _messageStatus.MessageCompletion.CancellationTokenRegistration = cancellationToken.Register(() =>
                {
                    SetCanceled(cancellationToken);
                });
            }
        }

        public long? GetMessageId()
        {
            lock (_mutex)
            {
                return _messageStatus.MessageId;
            }
        }

        public IMethod? GetMessageMethod()
        {
            lock (_mutex)
            {
                return _messageStatus.MessageCompletion.Method;
            }
        }

        public void SetSent(long messageId)
        {
            lock (_mutex)
            {
                _messageStatus.MessageState = MessageState.MessageSent;
                _messageStatus.MessageId = messageId;
                _messagesHandler?.MessagesTrackers.MessageCompletionTracker.AddCompletion(messageId, this);
                _messagesHandler?.MessagesTrackers.MessagesAckTracker.TrackMessage(this);
            }
        }

        public void SetToSend()
        {
            lock (_mutex)
            {
                if (CancellationToken.IsCancellationRequested)
                {
                    _logger.Verbose("Tried to send a canceled message (this is not an error)");
                    return;
                }

                if (_messagesHandler is null)
                {
                    throw new InvalidOperationException("MessageHandler is not set");
                }
                
                _messageStatus.MessageState = MessageState.NotYetSent;
                _messagesHandler?.MessagesQueue.PutInQueue(this);
            }
        }

        public void SetReplied(object? response)
        {
            lock (_mutex)
            {
                _messageStatus.MessageState = MessageState.Replied;
                if (response != null)
                {
                    _messageStatus.MessageCompletion.RpcMessage?.SetResponse(response);
                }

                _messageStatus.MessageCompletion.TaskCompletionSource?.TrySetResult();
                _messageStatus.MessageCompletion.CancellationTokenRegistration?.Unregister();
            }
        }

        public void SetFailed(Exception exception)
        {
            lock (_mutex)
            {
                _messageStatus.MessageState = MessageState.Failed;
                _messageStatus.MessageCompletion.TaskCompletionSource?.TrySetException(exception);
                _messageStatus.MessageCompletion.CancellationTokenRegistration?.Unregister();

                var messageId = GetMessageId();
                if (messageId != null)
                {
                    _messagesHandler?.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(messageId.Value, out _);
                }
            }
        }

        public void SetCanceled(CancellationToken? token = null)
        {
            lock (_mutex)
            {
                _messageStatus.MessageState = MessageState.Canceled;
                if (token != null)
                {
                    _messageStatus.MessageCompletion.TaskCompletionSource?.TrySetCanceled();
                }

                _messageStatus.MessageCompletion.CancellationTokenRegistration?.Unregister();

                var messageId = GetMessageId();
                if (messageId != null)
                {
                    _messagesHandler?.MessagesTrackers.MessagesAckTracker.StopTracking(messageId.Value);
                    _messagesHandler?.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(messageId.Value, out _);
                }
            }
        }

        public void SetAcknowledged()
        {
            lock (_mutex)
            {
                _messageStatus.MessageState = MessageState.Acknowledged;
                if (MessageSendingOptions.AwaiterType == AwaiterType.OnAcknowledgement)
                {
                    SetReplied(null);
                }
            }
        }

        public void BindTo(MessagesHandler messagesHandler)
        {
            lock (_mutex)
            {
                if (_messagesHandler != null)
                {
                    if (_messagesHandler == messagesHandler)
                    {
                        _logger.Warning("Tried to bind messageItem to the previous messages handler");
                        return;
                    }

                    var messageId = GetMessageId();
                    if (messageId.HasValue)
                    {
                        _messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(messageId.Value, out _);
                        _messagesHandler.MessagesTrackers.MessagesAckTracker.StopTracking(messageId.Value);
                    }
                }

                _messagesHandler = messagesHandler;
            }
        }
    }
}