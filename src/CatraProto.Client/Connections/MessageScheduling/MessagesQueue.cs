using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    class MessagesQueue
    {
        public int OutgoingCount
        {
            get => _concurrentQueue.Count;
        }

        private readonly ConcurrentQueue<MessageItem> _concurrentQueue = new ConcurrentQueue<MessageItem>();
        private readonly MessagesHandler _messagesHandler;
        private readonly ILogger _logger;

        public MessagesQueue(MessagesHandler messagesHandler, ILogger logger)
        {
            _messagesHandler = messagesHandler;
            _logger = logger.ForContext<MessagesQueue>();
        }

        public void EnqueueMessage(IObject body, MessageSendingOptions messageSendingOptions, IRpcMessage? rpcMessage, out Task completionTask, CancellationToken requestCancellationToken)
        {
            var taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            completionTask = taskCompletionSource.Task;
            var messageCompletion = new MessageCompletion(taskCompletionSource, rpcMessage, body is IMethod method ? method : null);
            var messageStatusTracker = new MessageStatus(messageCompletion);
            var messageItem = new MessageItem(body, messageSendingOptions, messageStatusTracker, _logger, requestCancellationToken);
            messageItem.BindTo(_messagesHandler);
            messageItem.SetToSend();
        }

        public void PutInQueue(MessageItem item, bool wakeUpLoop)
        {
            _concurrentQueue.Enqueue(item);
            if (wakeUpLoop)
            {
                _messagesHandler.Connection.WakeUpLoop();
            }
        }
        
        public bool TryGetMessage([MaybeNullWhen(false)]out MessageItem messageItem)
        {
            return _concurrentQueue.TryDequeue(out messageItem);
        }
    }
}