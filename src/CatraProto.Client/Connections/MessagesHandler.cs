using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using CatraProto.Async.Locks;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.MTProto;

namespace CatraProto.Client.Connections
{
    internal class MessagesHandler : IDisposable
    {
        private Channel<UnencryptedMessage> _unencryptedMessages = Channel.CreateUnbounded<UnencryptedMessage>();
        private Channel<EncryptedMessage> _encryptedMessages = Channel.CreateUnbounded<EncryptedMessage>();
        private ConcurrentDictionary<long, TaskCompletionSource<EncryptedMessage>> _encryptedCompletions = new ConcurrentDictionary<long, TaskCompletionSource<EncryptedMessage>>();
        private TaskCompletionSource<UnencryptedMessage> _oldTask;
        private AsyncLock _unencryptedMessagesLock = new AsyncLock();
        private MessageIdsHandler _messageIdsHandler;

        public MessagesHandler(MessageIdsHandler messageIdsHandler)
        {
            _messageIdsHandler = messageIdsHandler;
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
                await _unencryptedMessages.Writer.WriteAsync(message);
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
        
        public async Task<UnencryptedMessage> ListenOutgoingUnencrypted(CancellationToken token)
        {
            var message = await _unencryptedMessages.Reader.ReadAsync(token);
            if (message.MessageId == 0 || MessageIdsHandler.IsMessageIdOld(message.MessageId))
            {
                message.MessageId = _messageIdsHandler.GenerateMessageId();
            }

            return message;
        }
        
        public async Task QueueEncryptedMessage(EncryptedMessage message)
        {
            var completionSource = new TaskCompletionSource<EncryptedMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
            _encryptedCompletions.TryAdd(message.MessageId, completionSource);
            await _encryptedMessages.Writer.WriteAsync(message);
        }

        public bool CompleteEncryptedMessage(EncryptedMessage message, int messageId)
        {
            if (_encryptedCompletions.TryRemove(messageId, out var completionSource))
            {
                completionSource.TrySetResult(message);
                return true;
            }

            return false;
        }

        public async Task<EncryptedMessage> ListenOutgoingEncrypted(CancellationToken token)
        {
            var message = await _encryptedMessages.Reader.ReadAsync(token);
            if (MessageIdsHandler.IsMessageIdOld(message.MessageId))
            {
                _encryptedCompletions.Remove(message.MessageId, out var completionSource);
                var newMessageId = _messageIdsHandler.GenerateMessageId();
                message.MessageId = newMessageId;
                _encryptedCompletions.TryAdd(newMessageId, completionSource);
            }

            return message;
        }
        
        public void Dispose()
        {
            _unencryptedMessagesLock?.Dispose();
        }
    }
}