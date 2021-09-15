using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.Connections.MessageScheduling.Items;
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

        public bool RemoveCompletion(long messageId, [MaybeNullWhen(false)] out MessageItem messageItem)
        {
            return _messageCompletions.TryRemove(messageId, out messageItem);
        }

        public bool SetCompletion(long messageId, object response)
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
                    completion.SetReplied(response);
                    return true;
                }
            }

            if (GetMessageCompletion(messageId, out var messageCompletion))
            {
                messageCompletion.SetReplied(response);
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

            _logger.Warning("Couldn't find message id {Id}", messageId);
            return false;
        }
    }
}