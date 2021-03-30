using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using CatraProto.Async.Locks;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL.Schemas.CloudChats;
using Channel = System.Threading.Channels.Channel;
using EncryptedMessage = CatraProto.Client.Connections.Messages.EncryptedMessage;

namespace CatraProto.Client.Connections
{
    internal class MessagesHandler : IDisposable
    {
        private Channel<UnencryptedMessage> _unencryptedMessages = Channel.CreateUnbounded<UnencryptedMessage>();
        private Channel<EncryptedMessage> _encryptedMessages = Channel.CreateUnbounded<EncryptedMessage>();
        private ConcurrentDictionary<long, TaskCompletionSource<EncryptedMessage>> _encryptedCompletions = new ConcurrentDictionary<long, TaskCompletionSource<EncryptedMessage>>();
        private ConcurrentDictionary<long, CancellationTokenRegistration> _encryptedTokenRegistrations = new ConcurrentDictionary<long, CancellationTokenRegistration>();

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

        public async Task<Task<EncryptedMessage>> QueueEncryptedMessage(EncryptedMessage message)
        {
            var completionSource = new TaskCompletionSource<EncryptedMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
            _encryptedCompletions.TryAdd(message.MessageId, completionSource);
            RegisterMessageCancellation(message);
            await _encryptedMessages.Writer.WriteAsync(message);
            return completionSource.Task;
        }

        public bool CompleteEncryptedMessage(EncryptedMessage response, int messageId)
        {
            if (_encryptedCompletions.TryRemove(messageId, out var completionSource))
            {
                completionSource.TrySetResult(response);
                return true;
            }

            return false;
        }

        public async Task<EncryptedMessage> ListenOutgoingEncrypted(CancellationToken token)
        {
            var message = await _encryptedMessages.Reader.ReadAsync(token);
            if (MessageIdsHandler.IsMessageIdOld(message.MessageId))
            {
                ReassignEncryptedMessageId(message);
            }

            return message;
        }

        public async Task RemoveEncryptedMessage(EncryptedMessage message)
        {
            if (_encryptedCompletions.TryRemove(message.MessageId, out var completionSource))
            {
                completionSource.TrySetCanceled();
            }

            if (_encryptedTokenRegistrations.TryRemove(message.MessageId, out var cancellationTokenRegistration))
            {
                await cancellationTokenRegistration.DisposeAsync();
            }
        }

        private async Task ReassignEncryptedMessageId(EncryptedMessage message)
        {
            _encryptedCompletions.Remove(message.MessageId, out var completionSource);
            await DeleteCancellationRegistration(message);
            var newMessageId = _messageIdsHandler.GenerateMessageId();
            message.MessageId = newMessageId;
            RegisterMessageCancellation(message);
            _encryptedCompletions.TryAdd(newMessageId, completionSource);
        }

        private void RegisterMessageCancellation(EncryptedMessage message)
        {
            message.Token.Register(async () =>
            {
                if (_encryptedCompletions.TryRemove(message.MessageId, out var taskCompletionSource))
                {
                    taskCompletionSource.TrySetCanceled(message.Token);
                    await RemoveEncryptedMessage(message);
                }
            });
        }

        private async Task DeleteCancellationRegistration(EncryptedMessage message)
        {
            if (_encryptedTokenRegistrations.TryRemove(message.MessageId, out var toUnregister))
            {
                await toUnregister.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _unencryptedMessagesLock?.Dispose();
        }
    }
}