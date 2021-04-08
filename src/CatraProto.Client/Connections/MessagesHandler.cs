using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.MTProto;
using Channel = System.Threading.Channels.Channel;
using EncryptedMessage = CatraProto.Client.Connections.Messages.EncryptedMessage;

namespace CatraProto.Client.Connections
{
    internal class MessagesHandler : IDisposable
    {
        private ConcurrentDictionary<long, (CancellationTokenRegistration, TaskCompletionSource<EncryptedMessage>)> _encryptedMessages = new ConcurrentDictionary<long, (CancellationTokenRegistration, TaskCompletionSource<EncryptedMessage>)>();
        private Channel<UnencryptedMessage> _unencryptedChannel = Channel.CreateUnbounded<UnencryptedMessage>();
        private Channel<EncryptedMessage> _encryptedChannel = Channel.CreateUnbounded<EncryptedMessage>();
        private AsyncLock _unencryptedMessagesLock = new AsyncLock();
        private TaskCompletionSource<UnencryptedMessage> _oldTask;
        private MessageIdsHandler _messageIdsHandler;

        public MessagesHandler(MessageIdsHandler messageIdsHandler)
        {
            _messageIdsHandler = messageIdsHandler;
        }

        public async Task<UnencryptedMessage> ListenOutgoingUnencrypted(CancellationToken token)
        {
            var message = await _unencryptedChannel.Reader.ReadAsync(token);
            if (message.MessageId == 0 || MessageIdsHandler.IsMessageIdOld(message.MessageId))
            {
                message.MessageId = _messageIdsHandler.ComputeMessageId();
            }

            return message;
        }

        public async Task<Task<UnencryptedMessage>> QueueUnencryptedMessage(UnencryptedMessage message)
        {
            //This deserves an explanation.
            //UnencryptedMessages aren't identifiable by their MessageId since it is not persistent,
            //therefore, the best way to complete the correct task is to send one message after the previous one received a response

            using (await _unencryptedMessagesLock.LockAsync())
            {
                if (_oldTask != null)
                {
                    //Waiting for the old message to receive a response
                    await _oldTask.Task;
                }

                var completionSource = new TaskCompletionSource<UnencryptedMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
                _unencryptedChannel.Writer.TryWrite(message);
                _oldTask = completionSource;
                return completionSource.Task;
            }
        }

        public async Task<bool> CompleteUnencryptedMessage(UnencryptedMessage response)
        {
            using (await _unencryptedMessagesLock.LockAsync())
            {
                if (_oldTask == null)
                {
                    return false;
                }

                _oldTask.TrySetResult(response);
                _oldTask = null;
                return true;
            }
        }

        public async Task<EncryptedMessage> ListenOutgoingEncrypted(CancellationToken token)
        {
            var message = await _encryptedChannel.Reader.ReadAsync(token);
            if (MessageIdsHandler.IsMessageIdOld(message.MessageId))
            {
                ReassignEncryptedMessageId(message);
            }

            return message;
        }

        public void QueueEncryptedMessage(EncryptedMessage message, out Task<EncryptedMessage> completion)
        {
            var completionSource = new TaskCompletionSource<EncryptedMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
            var registration = RegisterMessageCancellation(message);
            _encryptedMessages.TryAdd(message.MessageId, (registration, completionSource));
            _encryptedChannel.Writer.TryWrite(message);
            completion = completionSource.Task;
        }

        public bool CompleteEncryptedMessage(EncryptedMessage response, int messageId)
        {
            if (_encryptedMessages.TryRemove(messageId, out var tuple))
            {
                tuple.Item1.Unregister();
                tuple.Item2.TrySetResult(response);
                return true;
            }

            return false;
        }

        private void ReassignEncryptedMessageId(EncryptedMessage message)
        {
            if (_encryptedMessages.TryRemove(message.MessageId, out var tuple))
            {
                var newMessageId = _messageIdsHandler.ComputeMessageId();
                tuple.Item1.Unregister();
                message.MessageId = newMessageId;
                var registration = RegisterMessageCancellation(message);
                _encryptedMessages.TryAdd(message.MessageId, (registration, tuple.Item2));
            }
        }

        private CancellationTokenRegistration RegisterMessageCancellation(EncryptedMessage message)
        {
            return message.Token.Register(() =>
            {
                if (_encryptedMessages.TryRemove(message.MessageId, out var tuple))
                {
                    tuple.Item2.TrySetCanceled();
                }
            });
        }


        public void Dispose()
        {
            _unencryptedMessagesLock?.Dispose();
        }
    }
}