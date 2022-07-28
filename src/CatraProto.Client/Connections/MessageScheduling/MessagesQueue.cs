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

using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling.Interfaces;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    internal class MessagesQueue : IMessagesQueue
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
            _logger.Information(messageTemplate: "Sending raw object {Item}", body);
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

            var count = Math.Min(_unencryptedQueue.Count, _concurrentQueue.Count);
            _logger.Information("Message {Item} added to queue", item.Body);
            if (wakeUpLoop)
            {
                _messagesHandler.Connection.SignalNewMessage(count > 1);
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