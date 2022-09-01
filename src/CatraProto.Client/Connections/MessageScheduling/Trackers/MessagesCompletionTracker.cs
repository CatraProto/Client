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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.TL.Interfaces;
using Serilog;

#endregion

namespace CatraProto.Client.Connections.MessageScheduling.Trackers
{
    internal class MessageCompletionTracker
    {
        private const int InitConnTime = 10;
        private readonly Dictionary<long, MessageItem> _messageCompletions = new Dictionary<long, MessageItem>();
        private readonly List<MessageItem> _unencryptedCompletions = new List<MessageItem>();
        private readonly object _mutex = new object();
        private readonly ILogger _logger;
        private bool _isClosed;
        //-2, must check, -1 no need to check, time has already passed otherwise check the time 
        private int _stopInitAt = -2;

        public MessageCompletionTracker(ILogger logger)
        {
            _logger = logger.ForContext<MessageCompletionTracker>();
        }

        public void AddCompletion(long messageId, MessageItem messageCompletion)
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    messageCompletion.SetCompleted(new ConnectionClosedError(), new ExecutionInfo(new ConnectionInfo(IPAddress.None, -1, -1, false)));
                    return;
                }

                _logger.Information(messageTemplate: "Adding completion for message {Message} with message id {MessageId}", messageCompletion, messageId);
                if (messageId == 0)
                {
                    _unencryptedCompletions.Add(messageCompletion);
                    return;
                }

                _messageCompletions.TryAdd(messageId, messageCompletion);
            }
        }

        public bool RemoveUnencryptedCompletion(MessageItem item)
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    return false;
                }

                return _unencryptedCompletions.Remove(item);
            }
        }

        public bool RemoveCompletion(long messageId, [MaybeNullWhen(false)] out MessageItem messageItem)
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    messageItem = null;
                    return false;
                }

                return _messageCompletions.Remove(messageId, out messageItem);
            }
        }

        public bool RemoveCompletions(long upperMessageId, [MaybeNullWhen(false)] out List<MessageItem> messageItems)
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    messageItems = null;
                    return false;
                }

                var query = _messageCompletions
                    .Where(x => x.Value.GetMessageState() is MessageState.MessageSent && x.Value.GetProtocolInfo().upperMsgId == upperMessageId)
                    .Select(x => x.Value)
                    .ToList();

                if (query.Count == 0)
                {
                    messageItems = null;
                    return false;
                }

                messageItems = query;
                return true;
            }
        }

        public bool SetCompletion(long messageId, object response, ExecutionInfo executionInfo)
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    return false;
                }

                if (messageId == 0)
                {

                    var responseType = response.GetType();
                    var completionIndex = _unencryptedCompletions.FindIndex(x =>
                    {
                        var method = x.GetMessageMethod();
                        if (method is not null)
                        {
                            if (response is RpcError)
                            {
                                return true;
                            }

                            if (x.CanCastResponse(response))
                            {
                                return true;
                            }
                        }

                        return false;
                    });

                    if (completionIndex == -1)
                    {
                        return false;
                    }

                    var completion = _unencryptedCompletions[completionIndex];
                    _unencryptedCompletions.RemoveAt(completionIndex);
                    completion.SetCompleted(response, executionInfo);
                    return true;
                }

                if (GetMessageCompletion(messageId, out var messageItem))
                {
                    if (_stopInitAt == -2 && messageItem.GetProtocolInfo().initConn && executionInfo.IsTelegramRpc && response is not RpcError)
                    {
                        _stopInitAt = ((int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()) + InitConnTime;
                    }
                    messageItem.SetCompleted(response, executionInfo);
                }

                return true;
            }
        }

        public bool GetRpcMethod(long messageId, [MaybeNullWhen(false)] out IMethod method, [MaybeNullWhen(false)] out MessageSendingOptions messageSendingOptions)
        {
            lock (_mutex)
            {
                messageSendingOptions = null;
                method = null;
                
                if (_isClosed)
                {
                    return false;
                }

                if (GetMessageCompletion(messageId, out var encryptedMessageCompletion, false))
                {
                    messageSendingOptions = encryptedMessageCompletion.MessageSendingOptions;
                    method = encryptedMessageCompletion.GetMessageMethod();
                    return method is not null;
                }

                return false;
            }
        }

        public void ResendAll()
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    return;
                }

                var getUnanswered = _messageCompletions
                    .Where(x => x.Value.GetMessageState() is MessageState.MessageSent or MessageState.Acknowledged)
                    .Select(x => x.Value)
                    .ToList();

                var messagesCount = getUnanswered.Count;
                foreach (var message in getUnanswered)
                {
                    _logger.Information("Resending message {Message}", message.Body);
                    message.SetToSend(true, true, true);
                }
            }
        }

        public bool GetMessageCompletion(long messageId, [MaybeNullWhen(false)] out MessageItem messageItem, bool remove = true)
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    messageItem = null;
                    return false;
                }

                if (_messageCompletions.TryGetValue(messageId, out messageItem))
                {
                    if (remove)
                    {
                        _messageCompletions.Remove(messageId, out _);
                    }

                    return true;
                }

                _logger.Warning("Couldn't find message Id {Id}. Maybe it has already received a response", messageId);
                return false;
            }
        }

        public bool SetAsAcknowledged(long messageId, ExecutionInfo executionInfo)
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    return false;
                }

                _logger.Information("Setting message {Id} as acknowledged", messageId);
                if (GetMessageCompletion(messageId, out var item, false))
                {
                    if (item.SetAcknowledged(executionInfo))
                    {
                        RemoveCompletion(messageId, out _);
                        _logger.Information("Removed message {Id} because it got completed by an acknowledgment", messageId);
                    }

                    return true;
                }

                return false;
            }
        }

        public IList<MessageItem> GetUnanswered(bool includeAcknowledged)
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    return new List<MessageItem>(0);
                }

                return _messageCompletions.Where(x =>
                {
                    var getStatus = x.Value.GetMessageState();
                    if (getStatus == MessageState.MessageSent || includeAcknowledged && getStatus == MessageState.Acknowledged)
                    {
                        return true;
                    }

                    return false;
                }).Select(x => x.Value).ToList();
            }
        }

        public bool OnNotFoundProtocolError(ExecutionInfo executionInfo)
        {
            lock (_mutex)
            {
                if (_isClosed)
                {
                    return false;
                }

                var error = new UnknownError("Incorrect server call", -404);
                var isSet = SetCompletion(0, error, executionInfo);
                if (isSet)
                {
                    return true;
                }

                var retTrue = false;
                foreach (var item in _messageCompletions)
                {
                    if (item.Value.GetMessageMethod() is BindTempAuthKey)
                    {
                        item.Value.SetCompleted(error, executionInfo);
                        retTrue = true;
                    }
                }

                return retTrue;
            }
        }

        public bool MustInitConnection()
        {
            lock (_mutex)
            {
                if (_stopInitAt == -1)
                {
                    return false;
                }
                else if (_stopInitAt == -2)
                {
                    return true;
                }
                else
                {
                    if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() - _stopInitAt > 10)
                    {
                        _stopInitAt = -1;
                        return false;
                    }
                    return true;
                }
            }
        }

        public void ResetInitConnection()
        {
            lock (_mutex)
            {
                _stopInitAt = -2;
            }
        }

        public void CloseTracker(ExecutionInfo executionInfo)
        {
            lock (_mutex)
            {
                _isClosed = true;
                var err = new ConnectionClosedError();
                foreach (var message in _messageCompletions)
                {
                    message.Value.SetCompleted(err, executionInfo);
                }
            }
        }
    }
}