using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Connections.Exceptions;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.MTProto.Containers;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class SendLoop : GenericLoop
    {
        private readonly MessagesHandler _messagesHandler;
        private readonly MTProtoState _mtProtoState;
        private readonly Connection _connection;
        private readonly Task?[] _encryptedTasks;
        private readonly ILogger _logger;

        public SendLoop(Connection connection, ILogger logger)
        {
            _encryptedTasks = new Task?[2];
            _connection = connection;
            _messagesHandler = _connection.MessagesHandler;
            _mtProtoState = _connection.MtProtoState;
            _logger = logger.ForContext<SendLoop>();
            Task.Run(Loop);
        }

        private async Task Loop()
        {
            _logger.Information("Listening for outgoing messages...");
            var pendingMessages = new List<MessageItem>();
            Task<MessageItem>? itemTask = null;
            while (true)
            {
                if (StateSignaler.GetCurrentState() != SignalState.Start)
                {
                    await StateSignaler.WaitAsync();
                }

                var shutdownToken = GetShutdownToken();

                //All of this is because we need unencrypted and encrypted messages and some special encrypted messages to be independent from each other
                try
                {
                    //If there's no outgoing message, we must still stay passive waiting either for a message
                    //or for the previous writing operation to complete
                    var count = _messagesHandler.MessagesQueue.OutgoingCount == 0 ? 1 : _messagesHandler.MessagesQueue.OutgoingCount;
                    for (var i = 0; i < count; i++)
                    {
                        //It doesn't really matter what task completes first, because if they somehow complete at the same time
                        //we are still going to read containerTask to check whether it has completed or not
                        //If containerTask doesn't complete in time, we are still not losing anything because
                        //the loop is going to run again, without resetting the task
                        //The generated container might be smaller because of the lost task, but it's not a big deal.
                        itemTask ??= _messagesHandler.MessagesQueue.GetMessageAsync(shutdownToken);
                        await Task.WhenAny(itemTask, _encryptedTasks[1] ?? itemTask, _encryptedTasks[0] ?? itemTask);
                        if (itemTask.IsCompleted)
                        {
                            var item = itemTask.Result;
                            if (item.CancellationToken.IsCancellationRequested)
                            {
                                _logger.Information("Ignoring message because cancellation is requested");
                                continue;
                            }

                            if (item.MessageSendingOptions.IsEncrypted)
                            {
                                switch (item.Body)
                                {
                                    case InvokeWithLayer invokeWithLayer:
                                        if (invokeWithLayer.Query is InitConnection)
                                        {
                                            _encryptedTasks[1] = SendEncryptedMessages(new List<MessageItem> { item });
                                        }
                                        else
                                        {
                                            pendingMessages.Add(item);
                                        }

                                        break;
                                    case BindTempAuthKey:
                                        _encryptedTasks[1] = SendEncryptedMessages(new List<MessageItem> { item });
                                        break;
                                    default:
                                        pendingMessages.Add(item);
                                        break;
                                }
                            }
                            else
                            {
                                await SendUnencryptedMessage(item);
                            }

                            itemTask = null;
                        }

                        for (var i1 = 0; i1 < _encryptedTasks.Length; i1++)
                        {
                            if (_encryptedTasks[i1]?.IsCompleted != true)
                            {
                                continue;
                            }

                            _encryptedTasks[i1]!.GetAwaiter().GetResult();
                            _encryptedTasks[i1] = null;
                        }
                    }

                    //This call will be reached anyway because
                    //if the containerTask completes, we're getting out of the loop
                    //if we read all messages, we're still getting out of the loop
                    //If there are no messages to read but pendingMessages has > 0 element(s)
                    //We are still getting out because with no encryptedTask to wait for, there would be no pendingMessage

                    //We don't risk to accumulate pendingMessages here, because we are sending a copy of the queue and
                    //then resetting it
                    if (pendingMessages.Count > 0 && _encryptedTasks[0] == null)
                    {
                        _encryptedTasks[0] = SendEncryptedMessages(_messagesHandler.MessagesTrackers.MessagesAckTracker.GetAcknowledgements().Concat(pendingMessages).ToList());
                        pendingMessages.Clear();
                    }
                }
                catch (OperationCanceledException e) when (e.CancellationToken == shutdownToken)
                {
                    //Ignored on purpose
                }
                catch (ConnectionClosedException)
                {
                    _ = _connection.ConnectAsync(shutdownToken);
                    break;
                }
                catch (IOException)
                {
                    _ = _connection.ConnectAsync(shutdownToken);
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error(e, string.Empty);
                }
            }

            _logger.Information("WriteLoop for connection {Info} shutdown", _connection.ConnectionInfo);
            SetLoopStopped();
        }


        private async Task SendUnencryptedMessage(MessageItem message)
        {
            if (SocketTools.TrySerialize(message, _logger, out var body))
            {
                var socketMessage = new UnencryptedConnectionMessage(_mtProtoState.MessageIdsHandler.ComputeMessageId(), body!);
                var serialized = socketMessage.Export();
                _logger.Information("Sending unencrypted message {Type} of size {Size} bytes", message.Body, serialized.Length);
                message.SetSent(0);
                await _connection.Protocol!.Writer!.SendAsync(serialized);
            }
        }

        private async Task SendEncryptedMessages(List<MessageItem> messages)
        {
            await _connection.Signaler.WaitAsync();
            AuthKey authKey;
            if (messages.Count == 1 && messages[0].MessageSendingOptions.SendWithAuthKey is not null)
            {
                authKey = messages[0].MessageSendingOptions.SendWithAuthKey!;
            }
            else
            {
                authKey = await _mtProtoState.KeysHandler.TemporaryAuthKey.GetAuthKeyAsync();
            }

            byte[] body;
            int seqno;
            long messageId;

            if (messages.Count == 1)
            {
                var message = messages[0];
                if (!SocketTools.TrySerialize(message, _logger, out body!))
                {
                    return;
                }

                var messageSendingOptions = message.MessageSendingOptions;
                messageId = messageSendingOptions.SendWithMessageId ?? _mtProtoState.MessageIdsHandler.ComputeMessageId();
                seqno = _mtProtoState.SeqnoHandler.ComputeSeqno(message.Body);
                message.SetSent(messageId);
            }
            else
            {
                var writer = new ContainersWriter(_logger);
                writer.CreateContainer(messages, _messagesHandler, _mtProtoState);
                body = writer.SerializedContainer!;
                messageId = _mtProtoState.MessageIdsHandler.ComputeMessageId();
                seqno = _mtProtoState.SeqnoHandler.ContentRelatedSent * 2;

                foreach (var t in writer.MessageItems)
                {
                    var messageItem = t.Item2;
                    messageItem.SetSent(t.Item1.MsgId);
                }
            }

            var encryptedMessage = new EncryptedConnectionMessage(authKey, messageId, _mtProtoState.SaltHandler.GetSalt(), _mtProtoState.SessionIdHandler.GetSessionId(), seqno, body);
            await _connection.Protocol!.Writer!.SendAsync(encryptedMessage.Export());
        }
    }
}