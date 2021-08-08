using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling.Trackers
{
    class MessageCompletionTracker
    {
        private readonly ConcurrentDictionary<long, MessageCompletion> _messageCompletions = new ConcurrentDictionary<long, MessageCompletion>();
        private readonly List<MessageCompletion> _unencryptedCompletions = new List<MessageCompletion>();
        private readonly object _mutex = new object();
        private readonly ILogger _logger;

        public MessageCompletionTracker(ILogger logger)
        {
            _logger = logger.ForContext<MessageCompletionTracker>();
        }

        public void AddCompletion(long messageId, MessageCompletion messageCompletion)
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

        public bool RemoveCompletion(long messageId, out MessageCompletion? messageCompletion)
        {
            return _messageCompletions.TryRemove(messageId, out messageCompletion);
        }

        public void CancelCompletion(long messageId, CancellationToken cancellationToken = default)
        {
            if (GetMessageCompletion(messageId, out var messageCompletion))
            {
                messageCompletion!.TaskCompletionSource?.TrySetCanceled(cancellationToken);
            }
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
                        if (x.Method is not null)
                        {
                            if (responseType.IsSubclassOf(x.Method.Type) || responseType == x.Method.Type)
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
                    completion.RpcMessage!.SetResponse(response);
                    completion.TaskCompletionSource?.TrySetResult();

                    _unencryptedCompletions.RemoveAt(completionIndex);
                    return true;
                }
            }

            if (GetMessageCompletion(messageId, out var messageCompletion))
            {
                if (messageCompletion!.TaskCompletionSource is null)
                {
                    return false;
                }

                messageCompletion.RpcMessage!.SetResponse(response);
                messageCompletion.TaskCompletionSource.TrySetResult();
            }

            return true;
        }

        public bool GetRpcMethod(long messageId, out IMethod? method)
        {
            if (GetMessageCompletion(messageId, out var encryptedMessageCompletion, false))
            {
                method = encryptedMessageCompletion!.Method;
                return true;
            }

            method = null;
            return false;
        }

        private bool GetMessageCompletion(long messageId, out MessageCompletion? messageCompletion, bool remove = true)
        {
            if (_messageCompletions.TryGetValue(messageId, out messageCompletion))
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