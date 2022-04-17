using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    internal class MessagesQueue
    {
        private readonly ConcurrentQueue<MessageItem> _concurrentQueue = new ConcurrentQueue<MessageItem>();
        private readonly ConcurrentQueue<MessageItem> _unencryptedQueue = new ConcurrentQueue<MessageItem>();
        private readonly MessagesHandler _messagesHandler;
        private readonly ILogger _logger;

        public MessagesQueue(MessagesHandler messagesHandler, ILogger logger)
        {
            _messagesHandler = messagesHandler;
            _logger = logger.ForContext<MessagesQueue>();
        }

        public void EnqueueMessage(IObject body, MessageSendingOptions messageSendingOptions, IRpcResponse? rpcMessage, out Task completionTask, CancellationToken requestCancellationToken)
        {
            var taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            completionTask = taskCompletionSource.Task;
            var messageCompletion = new MessageCompletion(taskCompletionSource, rpcMessage, body is IMethod method ? method : null);
            var messageStatusTracker = new MessageStatus(messageCompletion);
            var messageItem = new MessageItem(body, messageSendingOptions, messageStatusTracker, _logger, requestCancellationToken);
            messageItem.BindTo(_messagesHandler);
            messageItem.SetToSend();
        }

        public void SendObject(IObject body, MessageSendingOptions messageSendingOptions, CancellationToken requestCancellationToken)
        {
            var messageCompletion = new MessageCompletion(null, null, null);
            var messageStatusTracker = new MessageStatus(messageCompletion);
            var messageItem = new MessageItem(body, messageSendingOptions, messageStatusTracker, _logger, requestCancellationToken);
            messageItem.BindTo(_messagesHandler);
            messageItem.SetToSend();
        }

        public void PutInQueue(MessageItem item, bool wakeUpLoop)
        {
            if (item.MessageSendingOptions.IsEncrypted)
            {
                _concurrentQueue.Enqueue(item);
            }
            else
            {
                _unencryptedQueue.Enqueue(item);
            }

            if (wakeUpLoop)
            {
                _messagesHandler.Connection.SignalNewMessage();
            }
        }

        public bool TryGetMessage(bool encrypted, [MaybeNullWhen(false)] out MessageItem messageItem)
        {
            return encrypted ? _concurrentQueue.TryDequeue(out messageItem) : _unencryptedQueue.TryDequeue(out messageItem);
        }

        public int GetCount(bool encrypted)
        {
            return encrypted ? _concurrentQueue.Count : _unencryptedQueue.Count;
        }
    }
}