using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Awaiters;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.Extensions;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Containers;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;
using Serilog;
using Authorization = CatraProto.Client.TL.Schemas.CloudChats.Authorization;
using EncryptedMessage = CatraProto.Client.Connections.Messages.EncryptedMessage;

namespace CatraProto.Client.Connections.Loop
{
    class WriteLoop : Async.Loops.Loop
    {
        private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private ConnectionState _connectionState;
        private Connection _connection;
        private Task _encryptedTask;
        private ILogger _logger;

        public WriteLoop(Connection connection, ILogger logger)
        {
            _connection = connection;
            _connectionState = _connection.ConnectionState;
            _logger = logger.ForContext<WriteLoop>();
        }

        private async Task Loop()
        {
            _logger.Information("Listening for outgoing messages...");
            var pendingMessages = new List<MessageContainer>();
            Task<MessageContainer> containerTask = null;

            while (!_cancellationToken.IsCancellationRequested)
            {
                //All of this is because we need unencrypted and encrypted messages and some special encrypted messages to be independent from each other
                try
                {
                    //If there's no outgoing message, we must still stay passive waiting either for a message
                    //or for the previous writing operation to complete
                    var count = _connectionState.MessagesHandler.OutgoingCount == 0 ? 1 : _connectionState.MessagesHandler.OutgoingCount;
                    for (var i = 0; i < count; i++)
                    {
                        //It doesn't really matter what task completes first, because if they somehow complete at the same time
                        //we are still going to read containerTask to check whether it has completed or not
                        //If containerTask doesn't complete in time, we are still not losing anything because
                        //the loop is going to run again, without resetting the task
                        //The generated container might be smaller because of the lost task, but it's not a big deal.
                        containerTask ??= _connectionState.MessagesHandler.OutgoingMessages.Reader.ReadAsync(_cancellationToken.Token).AsTask();
                        await Task.WhenAny(containerTask, _encryptedTask ?? containerTask);

                        if (containerTask.IsCompleted)
                        {
                            var container = containerTask.Result;
                            if (container.OutgoingMessage.CancellationToken.IsCancellationRequested)
                            {
                                _logger.Information("Ignoring message because cancellation is requested");
                                continue;
                            }

                            if (container.OutgoingMessage.IsEncrypted)
                            {
                                switch (container.OutgoingMessage.Body)
                                {
                                    case BindTempAuthKey:
                                        _ = SendEncryptedMessages(new List<MessageContainer> { container }, true);
                                        break;
                                    default:
                                        pendingMessages.Add(container);
                                        break;
                                }
                            }
                            else
                            {
                                await SendUnencryptedMessage(container);
                            }

                            containerTask = null;
                        }

                        if (_encryptedTask?.IsCompleted == true)
                        {
                            if (_encryptedTask.IsFaulted)
                            {
                                throw _encryptedTask.Exception;
                            }

                            _encryptedTask = null;
                        }
                    }

                    //This call will be reached anyway because
                    //if the containerTask completes, we're getting out of the loop
                    //if we read all messages, we're still getting out of the loop
                    //If there are no messages to read but pendingMessages has > 0 element(s)
                    //We are still getting out because with no encryptedTask to wait for, there would be no pendingMessage

                    //We don't risk to accumulate pendingMessages here, because we are sending a copy of the queue and
                    //then resetting it
                    if (pendingMessages.Count > 0 && _encryptedTask == null)
                    {
                        var newList = new List<MessageContainer>();
                        var ack = _connectionState.AcknowledgementHandler.GetAckMessage();
                        if (ack != null)
                        {
                            newList.Add(new MessageContainer()
                            {
                                OutgoingMessage = new OutgoingMessage()
                                {
                                    IsEncrypted = true,
                                    Body = ack
                                }
                            });
                        }

                        _encryptedTask = SendEncryptedMessages(newList.Concat(pendingMessages).ToList());
                        pendingMessages.Clear();
                    }
                }
                catch (OperationCanceledException e) when (e.CancellationToken == _cancellationToken.Token)
                {
                    //Ignored on purpose
                }
                catch (Exception e)
                {
                    _logger.Error(e, string.Empty);
                }
            }

            _logger.Information("WriteLoop for connection {Info} shutdown", _connection.ConnectionInfo);
            SetLoopStopped();
        }

        private async Task SendUnencryptedMessage(MessageContainer message)
        {
            if (SocketTools.TrySerialize(message, _logger, out var body))
            {
                var socketMessage = new UnencryptedMessage
                {
                    Body = body,
                    MessageId = _connectionState.MessageIdsHandler.ComputeMessageId()
                };

                var serialized = socketMessage.Export();
                _logger.Information("Sending unencrypted message {Type} of size {Size} bytes", message.OutgoingMessage.Body, serialized.Length);
                await _connection.Protocol.Writer.SendAsync(serialized);
            }
        }

        //TODO: This thing really needs a refactoring
        private async Task SendEncryptedMessages(List<MessageContainer> messages, bool forceAuthKey = false)
        {
            await _connection.StateSignaler.WaitSignal();
            if (messages.Count == 1)
            {
                if (!SocketTools.TrySerialize(messages[0], _logger, out var requestBody))
                {
                    return;
                }

                var authKey = await _connection.ConnectionState.TemporaryAuthKey.GetAuthKeyAsync(forceReturn: forceAuthKey);
                var messageId = messages[0].OutgoingMessage.MessageOptions.SendWithMessageId != 0
                    ? messages[0].OutgoingMessage.MessageOptions.SendWithMessageId
                    : _connectionState.MessageIdsHandler.ComputeMessageId();
                var encryptedMessage = new EncryptedMessage(authKey)
                {
                    AuthKeyId = authKey.AuthKeyId,
                    Salt = _connection.ConnectionState.SaltHandler.GetSalt(),
                    SessionId = _connection.ConnectionState.SessionIdHandler.GetSessionId(),
                    MessageId = messageId,
                    SeqNo = _connection.ConnectionState.SeqnoHandler.ComputeSeqno(messages[0].OutgoingMessage.Body),
                    Body = requestBody,
                };

                _connectionState.MessagesHandler.AddSentMessage(encryptedMessage.MessageId, messages[0]);
                await _connection.Protocol.Writer.SendWithTimeoutAsync(encryptedMessage.Export(), _logger);
            }
            else
            {
                var writer = new ContainersWriter(_logger);
                writer.CreateContainer(messages, _connectionState);
                var authKey = await _connection.ConnectionState.TemporaryAuthKey.GetAuthKeyAsync();
                var encryptedMessage = new EncryptedMessage(authKey)
                {
                    AuthKeyId = authKey.AuthKeyId,
                    Salt = _connection.ConnectionState.SaltHandler.GetSalt(),
                    SessionId = _connection.ConnectionState.SessionIdHandler.GetSessionId(),
                    MessageId = _connection.ConnectionState.MessageIdsHandler.ComputeMessageId(),
                    SeqNo = _connection.ConnectionState.SeqnoHandler.ContentRelatedSent * 2,
                    Body = writer.SerializedContainer,
                };

                _logger.Information("Container {Id}", encryptedMessage.MessageId);
                for (var i = 0; i < writer.Messages.Count; i++)
                {
                    _logger.Information("Adding {Id}", writer.Messages[i].MsgId);
                    _connectionState.MessagesHandler.AddSentMessage(writer.Messages[i].MsgId, writer.MessageContainers[i]);
                }

                await _connection.Protocol.Writer.SendWithTimeoutAsync(encryptedMessage.Export(), _logger);
            }
        }

        protected override void StopSignal()
        {
            _cancellationToken.Cancel();
        }

        protected override Task StartSignal()
        {
            _ = Loop();
            return Task.CompletedTask;
        }
    }
}