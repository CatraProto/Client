using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Collections;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL.Interfaces;
using Serilog;

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
        private readonly ILogger _logger;

        public MessagesQueue(MessagesHandler messagesHandler, ILogger logger)
        {
            _messagesHandler = messagesHandler;
            _logger = logger;
        }

        public void EnqueueMessage(IObject body, MessageSendingOptions messageSendingOptions, IRpcMessage? rpcMessage, out Task? completionTask, CancellationToken requestCancellationToken)
        {
            var taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            
            completionTask = taskCompletionSource.Task;
            var messageCompletion = new MessageCompletion(taskCompletionSource, rpcMessage, body is IMethod method ? method : null);
            var messageStatusTracker = new MessageStatus(messageCompletion);
            var messageItem = new MessageItem(body, messageSendingOptions, messageStatusTracker, _logger, requestCancellationToken);
            EnqueueMessage(messageItem);
        }

        public void EnqueueMessage(MessageItem item)
        {
            item.BindTo(_messagesHandler);
            item.SetToSend();
        }

        public void PutInQueue(MessageItem item)
        {
            _asyncQueue.Enqueue(item);
        }
        
        public ValueTask<MessageItem> GetMessageAsync(CancellationToken token = default)
        {
            return _asyncQueue.DequeueAsync(token);
        }

        public void Dispose()
        {
            _asyncQueue.Dispose();
        }
    }
}