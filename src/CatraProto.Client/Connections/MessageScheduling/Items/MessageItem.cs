using System;
using System.Threading;
using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.MTProto;
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

        public void SetSent(long? upperId = null)
        {
            lock (_mutex)
            {
                var messageId = GetProtocolInfo().MessageId;
                if (messageId == null)
                {
                    throw new InvalidOperationException("Can't set as sent when message id is null");
                }

                if (upperId != null)
                {
                    _messageStatus.MessageProtocolInfo.UpperMessageId = upperId;
                }

                _messageStatus.MessageState = MessageState.MessageSent;
                _messagesHandler?.MessagesTrackers.MessageCompletionTracker.AddCompletion(messageId.Value, this);
                _messagesHandler?.MessagesTrackers.MessagesAckTracker.TrackMessage(this);
            }
        }

        public void SetToSend(bool resetProtocolInfo = true, bool wakeUpLoop = true, bool canDelete = false)
        {
            lock (_mutex)
            {
                if (_messagesHandler is null)
                {
                    throw new InvalidOperationException("MessageHandler is not set");
                }

                var (messageId, _) = GetProtocolInfo();
                if (messageId.HasValue)
                {
                    _messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(messageId.Value, out _);
                }

                if (CancellationToken.IsCancellationRequested)
                {
                    _logger.Verbose("Tried to send a canceled message (this is not an error)");
                    return;
                }

                if (resetProtocolInfo)
                {
                    SetProtocolInfo(null, null);
                }

                if (Body is MsgsAck msgsAck && canDelete)
                {
                    _logger.Information("MsgsAck got deleted, putting msgs back into acknowledge list");
                    foreach (var msg in msgsAck.MsgIds)
                    {
                        _messagesHandler.MessagesTrackers.MessagesAckTracker.AcknowledgeNext(msg);
                    }
                }
                else
                {
                    _messageStatus.MessageState = MessageState.NotYetSent;
                    _messagesHandler?.MessagesQueue.PutInQueue(this, wakeUpLoop);
                }
            }
        }

        public void SetReplied(object? response, ExecutionInfo executionInfo)
        {
            lock (_mutex)
            {
                _messageStatus.MessageState = MessageState.Replied;
                if (response != null)
                {
                    _messageStatus.MessageCompletion.RpcMessage?.SetResponse(response, executionInfo);
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

                var messageId = GetProtocolInfo().MessageId;
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

                var messageId = GetProtocolInfo().MessageId;
                if (messageId != null)
                {
                    _messagesHandler?.MessagesTrackers.MessagesAckTracker.StopTracking(messageId.Value);
                    _messagesHandler?.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(messageId.Value, out _);
                }
            }
        }

        public void SetAcknowledged(ExecutionInfo executionInfo)
        {
            lock (_mutex)
            {
                _messageStatus.MessageState = MessageState.Acknowledged;
                if (MessageSendingOptions.AwaiterType == AwaiterType.OnAcknowledgement)
                {
                    SetReplied(null, executionInfo);
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

                    var messageId = GetProtocolInfo().MessageId;
                    if (messageId.HasValue)
                    {
                        _messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(messageId.Value, out _);
                        _messagesHandler.MessagesTrackers.MessagesAckTracker.StopTracking(messageId.Value);
                    }
                }

                _messagesHandler = messagesHandler;
            }
        }

        public (long? MessageId, int? SeqNo) GetProtocolInfo()
        {
            lock (_mutex)
            {
                return (_messageStatus.MessageProtocolInfo.MessageId, _messageStatus.MessageProtocolInfo.SeqNo);
            }
        }

        public void SetProtocolInfo(long? messageId, int? seqNo, bool force = false)
        {
            lock (_mutex)
            {
                if (MessageSendingOptions.SendWithMessageId.HasValue && !force)
                {
                    _messageStatus.MessageProtocolInfo.MessageId = MessageSendingOptions.SendWithMessageId.Value;
                }
                else
                {
                    _messageStatus.MessageProtocolInfo.MessageId = messageId;
                }

                _messageStatus.MessageProtocolInfo.SeqNo = seqNo;
            }
        }

        public IMethod? GetMessageMethod()
        {
            lock (_mutex)
            {
                return _messageStatus.MessageCompletion.Method;
            }
        }

        public MessageState GetMessageState()
        {
            lock (_mutex)
            {
                return _messageStatus.MessageState;
            }
        }
    }
}