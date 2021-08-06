using System.Collections.Concurrent;
using System.Threading;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling.Trackers
{
    class MessageCompletionTracker
    {
        private readonly ConcurrentDictionary<long, MessageCompletion> _messageCompletions = new ConcurrentDictionary<long, MessageCompletion>();
        private readonly ILogger _logger;

        public MessageCompletionTracker(ILogger logger)
        {
            _logger = logger.ForContext<MessageCompletionTracker>();
        }

        public void AddCompletion(long messageId, MessageCompletion messageCompletion)
        {
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

        public void SetCompletion(long messageId, object response)
        {
            if (GetMessageCompletion(messageId, out var messageCompletion))
            {
                if (messageCompletion!.TaskCompletionSource is null)
                {
                    return;
                }

                messageCompletion.RpcMessage!.SetResponse(response);
                messageCompletion.TaskCompletionSource.TrySetResult();
            }
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