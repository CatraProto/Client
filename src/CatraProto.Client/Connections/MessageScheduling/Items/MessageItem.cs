/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

#region

using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

#endregion

namespace CatraProto.Client.Connections.MessageScheduling.Items
{
    internal class MessageItem
    {
        public MessageSendingOptions MessageSendingOptions { get; }
        public CancellationToken CancellationToken { get; }
        public IObject Body { get; }

        private int _trackId = CryptoTools.CreateRandomInt();
        private readonly object _mutex = new object();
        private readonly MessageStatus _messageStatus;
        private MessagesHandler? _messagesHandler;
        private readonly ILogger _logger;

        public MessageItem(IObject body, MessageSendingOptions messageSendingOptions, MessageStatus messageStatus, ILogger logger, CancellationToken cancellationToken)
        {
            Body = body;
            MessageSendingOptions = messageSendingOptions;
            _logger = logger.ForContext<MessageItem>().ForContext("MessageItemTrackId", ToString());
            CancellationToken = cancellationToken;
            _messageStatus = messageStatus;

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

        public void SetSent(ExecutionInfo executionInfo, long? upperId = null, int? upperSeqno = null)
        {
            lock (_mutex)
            {
                var messageId = GetProtocolInfo().MessageId;
                if (messageId == null)
                {
                    throw new InvalidOperationException("Can't set as sent when message id is null");
                }

                _logger.Information("Message sent with id {MessageId} and upperId {upperId}", messageId, upperId);
                if (upperId != null)
                {
                    _messageStatus.MessageProtocolInfo.UpperMessageId = upperId;
                    _messageStatus.MessageProtocolInfo.UpperSeqno = upperSeqno;
                }
                
                _messageStatus.MessageState = MessageState.MessageSent;
                if (MessageSendingOptions.AwaiterType == AwaiterType.OnSent)
                {
                    SetCompleted(null, executionInfo);
                }
                else
                {
                    _messagesHandler?.MessagesTrackers.MessageCompletionTracker.AddCompletion(messageId.Value, this);
                }
            }
        }

        public void SetOnHold(bool resetProtocolInfo = true, bool wakeUpLoop = true, bool canDelete = false)
        {
            if (GetMessageState() is MessageState.Completed or MessageState.Failed or MessageState.Canceled)
            {
                _logger.Verbose("Tried to send an already completed or failed message (this is not an error)");
                return;
            }

            _messageStatus.MessageState = MessageState.NotYetSent;
        }

        public void SetToSend(bool resetProtocolInfo = true, bool wakeUpLoop = true, bool canDelete = false)
        {
            lock (_mutex)
            {
                if (GetMessageState() is MessageState.Completed or MessageState.Failed)
                {
                    _logger.Verbose("Tried to send an already completed or failed message (this is not an error)");
                    return;
                }

                if (CancellationToken.IsCancellationRequested)
                {
                    _logger.Verbose("Tried to send a canceled message (this is not an error)");
                    return;
                }

                if (_messagesHandler is null)
                {
                    throw new InvalidOperationException("MessageHandler is not set");
                }

                _logger.Information("Setting message with id {MessageId} as to be sent", _messageStatus.MessageProtocolInfo.MessageId);
                RemoveSelfFromTrackers();
                
                if (resetProtocolInfo)
                {
                    SetProtocolInfo(null, null, false, true);
                }

                if (Body is MsgsAck msgsAck && canDelete)
                {
                    _logger.Information("MsgsAck got deleted, putting msgs back into acknowledge list");
                    foreach (var msg in msgsAck.MsgIds)
                    {
                        _messagesHandler.MessagesTrackers.AcknowledgementHandler.SetAsNeedsAck(msg);
                    }
                }
                else
                {
                    _logger.Information("Setting message as NotYetSent");
                    _messageStatus.MessageState = MessageState.NotYetSent;
                    _messagesHandler?.MessagesQueue.PutInQueue(this, wakeUpLoop);
                }
            }
        }

        public void SetCompleted(object? response, ExecutionInfo executionInfo)
        {
            lock (_mutex)
            {
                _messageStatus.MessageState = MessageState.Completed;
                if (response != null)
                {
                    _messageStatus.MessageCompletion.RpcResponse?.SetResponse(response, executionInfo);
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

                RemoveSelfFromTrackers();
            }
        }

        public void SetCanceled(CancellationToken? token = null)
        {
            lock (_mutex)
            {
                _messageStatus.MessageState = MessageState.Canceled;
                if (token != null)
                {
                    _messageStatus.MessageCompletion.TaskCompletionSource?.TrySetCanceled(token.Value);
                }
                else
                {
                    _messageStatus.MessageCompletion.TaskCompletionSource?.TrySetCanceled();
                }

                RemoveSelfFromTrackers();
                _messageStatus.MessageCompletion.CancellationTokenRegistration?.Unregister();
            }
        }

        public bool SetAcknowledged(ExecutionInfo executionInfo)
        {
            lock (_mutex)
            {
                if (_messageStatus.MessageState < MessageState.Acknowledged)
                {
                    _messageStatus.MessageState = MessageState.Acknowledged;
                    if (MessageSendingOptions.AwaiterType == AwaiterType.OnAcknowledgement)
                    {
                        SetCompleted(null, executionInfo);
                        return true;
                    }
                }

                return false;
            }
        }

        public void BindTo(MessagesHandler messagesHandler, bool resetMessageInfo = false)
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

                    RemoveSelfFromTrackers();
                }

                if (resetMessageInfo)
                {
                    SetProtocolInfo(null, null, null, true);
                }

                _messagesHandler = messagesHandler;
            }
        }

        public (long? MessageId, int? SeqNo, long? upperMsgId, long? upperSeqno, bool initConn) GetProtocolInfo()
        {
            lock (_mutex)
            {
                return (_messageStatus.MessageProtocolInfo.MessageId, _messageStatus.MessageProtocolInfo.SeqNo, _messageStatus.MessageProtocolInfo.UpperMessageId, _messageStatus.MessageProtocolInfo.UpperSeqno, _messageStatus.MessageProtocolInfo.InitConn);
            }
        }

        public void SetProtocolInfo(long? messageId, int? seqNo, bool? initConn = null, bool set = false)
        {
            lock (_mutex)
            {
                _logger.Information("Setting message Id from {FromId} to {ToId}", _messageStatus.MessageProtocolInfo.MessageId, messageId);
                if (set)
                {
                    _messageStatus.MessageProtocolInfo.MessageId = messageId;
                    _messageStatus.MessageProtocolInfo.SeqNo = seqNo;
                    _messageStatus.MessageProtocolInfo.InitConn = initConn ?? false;
                }
                else
                {
                    if (MessageSendingOptions.SendWithMessageId is not null)
                    {
                        _logger.Information("Ignoring set message Id from {FromId} to {ToId} because SendWithMessageId {SendWith} is set", _messageStatus.MessageProtocolInfo.MessageId, messageId, MessageSendingOptions.SendWithMessageId.Value);
                        _messageStatus.MessageProtocolInfo.MessageId = MessageSendingOptions.SendWithMessageId.Value;
                    }
                    else if (messageId is not null)
                    {
                        _messageStatus.MessageProtocolInfo.MessageId = messageId.Value;
                    }

                    if (seqNo is not null)
                    {
                        _messageStatus.MessageProtocolInfo.SeqNo = seqNo.Value;
                    }

                    if (initConn is not null)
                    {
                        _messageStatus.MessageProtocolInfo.InitConn = initConn.Value;
                    }
                }
            }
        }

        public bool CanCastResponse(object o)
        {
            lock (_mutex)
            {
                var rpcResponse = _messageStatus.MessageCompletion.RpcResponse;
                if (rpcResponse is null || !rpcResponse.CanCast(o))
                {
                    return false;
                }
                return true;
            }
        }

        public IMethod? GetMessageMethod()
        {
            lock (_mutex)
            {
                return _messageStatus.MessageCompletion.Method;
            }
        }

        public Task? GetMessageTask()
        {
            lock (_mutex)
            {
                return _messageStatus.MessageCompletion.TaskCompletionSource?.Task;
            }
        }

        public MessageState GetMessageState()
        {
            lock (_mutex)
            {
                return _messageStatus.MessageState;
            }
        }

        private void RemoveSelfFromTrackers()
        {
            lock (_mutex)
            {
                var messageId = GetProtocolInfo().MessageId;
                if (!messageId.HasValue)
                {
                    return;
                }

                if (MessageSendingOptions.IsEncrypted)
                {
                    _messagesHandler?.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(messageId.Value, out _);
                }
                else
                {
                    _messagesHandler?.MessagesTrackers.MessageCompletionTracker.RemoveUnencryptedCompletion(this);
                }
            }
        }

        public override string ToString()
        {
            return $"[Body: {Body} TrackId: {_trackId}]";
        }
    }
}