using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling.Trackers
{
    class MessageCompletionTracker
    {
        private readonly ConcurrentDictionary<long, MessageItem> _messageCompletions = new ConcurrentDictionary<long, MessageItem>();
        private readonly List<MessageItem> _unencryptedCompletions = new List<MessageItem>();
        private readonly object _mutex = new object();
        private readonly ILogger _logger;

        public MessageCompletionTracker(ILogger logger)
        {
            _logger = logger.ForContext<MessageCompletionTracker>();
        }

        public void AddCompletion(long messageId, MessageItem messageCompletion)
        {
            if (messageId == 0)
            {
                lock (_mutex)
                {
                    _unencryptedCompletions.Add(messageCompletion);
                }

                return;
            }

            _messageCompletions.TryAdd(messageId, messageCompletion);
        }

        public bool RemoveUnencryptedCompletion(MessageItem item)
        {
            lock (_mutex)
            {
                return _unencryptedCompletions.Remove(item);
            }
        }

        public bool RemoveCompletion(long messageId, [MaybeNullWhen(false)] out MessageItem messageItem)
        {
            return _messageCompletions.TryRemove(messageId, out messageItem);
        }

        public bool RemoveCompletions(long upperMessageId, [MaybeNullWhen(false)] out List<MessageItem> messageItems)
        {
            var query = _messageCompletions.Where(x => x.Value.GetMessageState() is MessageState.MessageSent && x.Value.GetProtocolInfo().upperMsgId == upperMessageId).Select(x => x.Value).ToList();

            if (query.Count == 0)
            {
                messageItems = null;
                return false;
            }

            messageItems = query;
            return true;
        }

        public bool SetCompletion(long messageId, object response, ExecutionInfo executionInfo)
        {
            if (messageId == 0)
            {
                lock (_mutex)
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

                            if (responseType.IsSubclassOf(method.Type) || responseType == method.Type)
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
            }

            if (GetMessageCompletion(messageId, out var messageCompletion))
            {
                messageCompletion.SetCompleted(response, executionInfo);
            }

            return true;
        }

        public bool GetRpcMethod(long messageId, out IMethod? method)
        {
            if (GetMessageCompletion(messageId, out var encryptedMessageCompletion, false))
            {
                method = encryptedMessageCompletion.GetMessageMethod();
                return true;
            }

            method = null;
            return false;
        }

        private bool GetMessageCompletion(long messageId, [MaybeNullWhen(false)] out MessageItem messageItem, bool remove = true)
        {
            if (_messageCompletions.TryGetValue(messageId, out messageItem))
            {
                if (remove)
                {
                    _messageCompletions.TryRemove(messageId, out _);
                }

                return true;
            }

            _logger.Warning("Couldn't find message Id {Id}. Maybe it has already received a response", messageId);
            return false;
        }

        public bool SetAsAcknowledged(long messageId, ExecutionInfo executionInfo)
        {
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

        public IList<MessageItem> GetUnanswered(bool includeAcknowledged)
        {
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

        public bool OnNotFoundProtocolError(ExecutionInfo executionInfo)
        {
            var error = new RpcError { ErrorCode = -404, ErrorMessage = "Incorrect server call" };
            var isSet = SetCompletion(0, error, executionInfo);
            if (isSet)
            {
                return true;
            }

            foreach (var item in _messageCompletions)
            {
                if (item.Value.GetMessageMethod() is BindTempAuthKey)
                {
                    item.Value.SetCompleted(error, executionInfo);
                    return true;
                }
            }

            return false;
        }
    }
}