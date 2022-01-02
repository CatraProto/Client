using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Containers;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class SendLoop : LoopImplementation<ResumableLoopState, ResumableSignalState>
    {
        private readonly MessagesHandler _messagesHandler;
        private readonly MTProtoState _mtProtoState;
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public SendLoop(Connection connection, ILogger logger)
        {
            _connection = connection;
            _messagesHandler = _connection.MessagesHandler;
            _mtProtoState = _connection.MtProtoState;
            _logger = logger.ForContext<SendLoop>();
        }

        public override async Task LoopAsync(CancellationToken stoppingToken)
        {
            var currentState = StateSignaler.GetCurrentState(true);
            while (true)
            {
                if (currentState!.AlreadyHandled)
                {
                    currentState = StateSignaler.GetCurrentState(true);
                }

                if (!currentState!.AlreadyHandled)
                {
                    switch (currentState.Signal)
                    {
                        case ResumableSignalState.Start:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Information("Send loop started for connection {Connection}", _connection.ConnectionInfo);
                            break;
                        case ResumableSignalState.Stop:
                            _logger.Information("Send loop stopped for connection {Connection}", _connection.ConnectionInfo);
                            SetSignalHandled(ResumableLoopState.Stopped, currentState);
                            return;
                        case ResumableSignalState.Resume:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Verbose("Send loop for connection {Connection} woken up", _connection.ConnectionInfo);
                            break;
                        case ResumableSignalState.Suspend:
                            SetSignalHandled(ResumableLoopState.Suspended, currentState);
                            _logger.Verbose("Send loop for connection {Connection} paused. Waiting for signal...", _connection.ConnectionInfo);
                            currentState = await StateSignaler.WaitAsync(stoppingToken);
                            break;
                    }
                }

                await UnencryptedTickAsync(stoppingToken);
                
                if (!_mtProtoState.KeysHandler.TemporaryAuthKey.HasExpired())
                {
                    await EncryptedTickAsync(stoppingToken);
                }
            }
        }


        private async Task EncryptedTickAsync(CancellationToken stoppingToken)
        {
            var encryptedList = new Lazy<List<MessageItem>>(() => new List<MessageItem>(1));
            var getAcks = _mtProtoState.Connection.MessagesHandler.MessagesTrackers.AcknowledgementHandler.GetAckMessages();

            //Can't use Concat here because Lazy<T> doesn't allow setting the Value property
            foreach (var x in getAcks)
            {
                x.BindTo(_connection.MessagesHandler);
                encryptedList.Value.Add(x);
            }

            var count = _messagesHandler.MessagesQueue.GetCount(true);
            var totalSent = 0;
            if (count > 0)
            {
                _logger.Verbose("Pulling {Count} encrypted messages out of queue to send to {Connection}...", count, _connection.ConnectionInfo);
                for (int i = 0; i < count; i++)
                {
                    if (!_messagesHandler.MessagesQueue.TryGetMessage(true, out var messageItem))
                    {
                        _logger.Error("RACE CONDITION");
                        break;
                    }

                    if (stoppingToken.IsCancellationRequested)
                    {
                        return;
                    }
                    
                    if (messageItem.CancellationToken.IsCancellationRequested)
                    {
                        continue;
                    }

                    if (_mtProtoState.KeysHandler.TemporaryAuthKey.CanBeUsed())
                    {
                        if (messageItem.Body is InvokeWithLayer { Query: InitConnection })
                        {
                            encryptedList.Value.Add(messageItem);
                            break;
                        }
                        
                        if (!_connection.GetIsInited())
                        {
                            messageItem.SetToSend(wakeUpLoop: false);
                            continue;
                        }

                        encryptedList.Value.Add(messageItem);
                    }
                    else
                    {
                        //These messages will only be sent when TemporaryAuthKey.CanBeUsed is false because for it to be true the connection needs to be Initialized
                        //This way, we're only gonna send this message
                        if (messageItem.Body is BindTempAuthKey)
                        {
                            encryptedList.Value.Add(messageItem);
                            break;
                        }

                        //Even if we check afterwards, it's better to check here because we'll avoid allocating a List
                        //The reason why we check twice is that the key may be invalid at any time
                        _logger.Verbose("Skipping {Message} because authorization key is not ready (while dequeuing)", messageItem.Body);

                        //Not waking up the loop because it's going to be woken up by the authorization key generation.
                        messageItem.SetToSend(wakeUpLoop: false, canDelete: true);
                    }
                }

                if (encryptedList.IsValueCreated)
                {
                    IObject upperMost;
                    byte[]? msgSerialization;
                    List<MessageItem> finalItems;
                    var seqBef = _mtProtoState.SeqnoHandler.ContentRelatedSent;

                    if (encryptedList.Value.Count == 1)
                    {
                        var message = encryptedList.Value[0];
                        if (SocketTools.TrySerialize(message, _logger, out msgSerialization))
                        {
                            if (!_mtProtoState.KeysHandler.TemporaryAuthKey.CanBeUsed() && message.Body is not InvokeWithLayer { Query: InitConnection } && message.Body is not BindTempAuthKey && message.Body is not MsgsAck)
                            {
                                _logger.Verbose("Postponing {Message} because the authorization key is not ready", message.Body);

                                //Not waking up the loop because it's going to be woken up by the authorization key generation.
                                message.SetToSend(wakeUpLoop: false, canDelete: true);
                                return;
                            }

                            finalItems = encryptedList.Value;
                            upperMost = message.Body;
                            totalSent++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (ContainersWriter.GetContainer(encryptedList.Value, _mtProtoState, out var containerizedItems, out msgSerialization, _logger))
                    {
                        if (!_mtProtoState.KeysHandler.TemporaryAuthKey.CanBeUsed())
                        {
                            //After generating the container we have increased the seqno number, but these messages aren't going to be sent so we need to rollback the changes
                            _mtProtoState.SeqnoHandler.ContentRelatedSent = seqBef;

                            _logger.Verbose("Postponing container of {MessageCount} because the authorization key is not ready", containerizedItems.Count);
                            //Not waking up the loop because it's going to be woken up by the authorization key generation.
                            containerizedItems.SetToSend(false);
                            return;
                        }

                        _logger.Information("Sending {Count} messages inside of a container", containerizedItems.Count);
                        finalItems = containerizedItems;
                        upperMost = new MsgContainer();
                        totalSent += containerizedItems.Count;
                    }
                    else
                    {
                        return;
                    }

                    await SendEncryptedAsync(upperMost, finalItems, msgSerialization);
                }

                _logger.Information("Sent {Count} messages to {Connection}", totalSent, _connection.ConnectionInfo);
            }
        }

        public async Task UnencryptedTickAsync(CancellationToken stoppingToken)
        {
            var count = _messagesHandler.MessagesQueue.GetCount(false);
            var totalSent = 0;
            if (count > 0)
            {
                _logger.Verbose("Pulling {Count} unencrypted messages out of queue to send to {Connection}...", count, _connection.ConnectionInfo);
                for (int i = 0; i < count; i++)
                {
                    if (!_messagesHandler.MessagesQueue.TryGetMessage(false, out var messageItem))
                    {
                        _logger.Error("RACE CONDITION");
                        break;
                    }
                    
                    if (stoppingToken.IsCancellationRequested)
                    {
                        return;
                    }
                    
                    if (messageItem.CancellationToken.IsCancellationRequested)
                    {
                        continue;
                    }
                    
                    _logger.Verbose("{Item} is not going to be sent as encrypted", messageItem.Body);
                    await SendUnencryptedAsync(messageItem, stoppingToken);
                    totalSent++;
                }
            }
        }

        public async Task SendEncryptedAsync(IObject upperMost, IList<MessageItem> messages, byte[] payload)
        {
            var authKey = _mtProtoState.KeysHandler.TemporaryAuthKey.GetCachedKey();
            var sessionId = _mtProtoState.SessionIdHandler.GetSessionId();
            var getSalt = _mtProtoState.SaltHandler.GetSalt();
            var messageId = _mtProtoState.MessageIdsHandler.ComputeMessageId();

            var seqno = _mtProtoState.SeqnoHandler.ComputeSeqno(upperMost);
            if (messages.Count == 1)
            {
                messages[0].SetProtocolInfo(messageId, seqno);
                messageId = messages[0].GetProtocolInfo().MessageId!.Value;
            }

            var encryptedMsg = new EncryptedConnectionMessage(authKey, messageId, getSalt, sessionId, seqno, payload);
            messages.SetSent(_connection.MessagesDispatcher.GetExecInfo(), encryptedMsg.MessageId, seqno);
            await _connection.Protocol.Writer.SendAsync(encryptedMsg.Export());
        }

        public async Task SendUnencryptedAsync(MessageItem messageItem, CancellationToken token)
        {
            if (SocketTools.TrySerialize(messageItem, _logger, out var serializedBody))
            {
                var messageId = _connection.MtProtoState.MessageIdsHandler.ComputeMessageId();
                var unencryptedMessage = new UnencryptedConnectionMessage(messageId, serializedBody);
                messageItem.SetProtocolInfo(0, 0);
                messageItem.SetSent(_connection.MessagesDispatcher.GetExecInfo());
                var unencryptedBody = unencryptedMessage.Export();
                await _connection.Protocol.Writer.SendAsync(unencryptedBody, token);
                _logger.Verbose("Sent unencrypted message to {Connection}", _connection.ConnectionInfo);
            }
        }

        private void AskReconnection()
        {
            _logger.Information("SendLoop asking to reconnect to {Info}", _connection.ConnectionInfo);
            _connection.ConnectAsync();
        }

        public override string ToString() => $"Send loop for connection {_connection.ConnectionInfo}";
    }
}