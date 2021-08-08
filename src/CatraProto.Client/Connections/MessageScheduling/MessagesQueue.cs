using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Collections;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Connections.MessageScheduling
{
    class MessagesQueue : IDisposable
    {
        public int OutgoingCount
        {
            get => _asyncQueue.GetCount();
        }

        private readonly AsyncQueue<MessageItem> _asyncQueue = new AsyncQueue<MessageItem>();
        private readonly MessagesHandler _messagesHandler;

        public MessagesQueue(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public void EnqueueMessage(IObject body, MessageSendingOptions messageSendingOptions, IRpcMessage rpcMessage, out Task completionTask, CancellationToken requestCancellationToken)
        {
            requestCancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            completionTask = taskCompletionSource.Task;

            var messageCompletion = new MessageCompletion(taskCompletionSource, rpcMessage, body is IMethod method ? method : null);
            var messageStatusTracker = new MessageStatus(messageCompletion);
            var messageItem = new MessageItem(body, messageSendingOptions, messageStatusTracker, requestCancellationToken);
            messageItem.BindTo(_messagesHandler);

            _asyncQueue.Enqueue(messageItem);
        }

        public void EnqueueMessage(MessageItem item)
        {
            _asyncQueue.Enqueue(item);
        }

        public Task<MessageItem> GetMessageAsync(CancellationToken token = default)
        {
            return _asyncQueue.DequeueAsync(token);
        }

        public void Dispose()
        {
            _asyncQueue.Dispose();
        }
    }
}