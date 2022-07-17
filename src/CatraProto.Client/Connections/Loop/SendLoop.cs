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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.ApiManagers;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    internal class SendLoop : LoopImplementation<ResumableLoopState, ResumableSignalState>
    {

        public const int ContainerMessagesLimit = 1020;
        public const int ContainerBytesLimit = 2 << 15;
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
                            _messagesHandler.MessagesTrackers.MessageCompletionTracker.ResetInitConnection();
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Information("Send loop started");
                            break;
                        case ResumableSignalState.Stop:
                            _logger.Information("Send loop stopped");
                            SetSignalHandled(ResumableLoopState.Stopped, currentState);
                            return;
                        case ResumableSignalState.Resume:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Verbose("Send loop for woken up");
                            break;
                        case ResumableSignalState.Suspend:
                            SetSignalHandled(ResumableLoopState.Suspended, currentState);
                            _logger.Verbose("Send loop paused. Waiting for signal...");
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
            var addBack = new Lazy<List<MessageItem>>(() => new List<MessageItem>(1));
            var encryptedList = new Lazy<List<MessageItem>>(() => new List<MessageItem>(1));

            var totalSent = 0;
            var mustWrap = false;
            while (_messagesHandler.MessagesQueue.TryGetMessage(true, out var messageItem))
            {
                _logger.Information("Pulled out from queue message {Message}", messageItem.Body);
                if (stoppingToken.IsCancellationRequested)
                {
                    return;
                }

                if (messageItem.CancellationToken.IsCancellationRequested)
                {
                    continue;
                }

                if (messageItem.Body is MsgsStateReq)
                {
                    encryptedList.Value.Add(messageItem);
                    break;
                }

                var currentState = _mtProtoState.Client.LoginManager.GetCurrentState();
                if (messageItem.Body is IMethod method && !LoginManager.CanBeUnauthenticated(method) && currentState is not LoginState.LoggedIn)
                {
                    _logger.Information("Postponing {Body} because we are not authorized, current state is {CurrentState}", method, currentState);
                    addBack.Value.Add(messageItem);
                    continue;
                }

                if (_mtProtoState.KeysHandler.TemporaryAuthKey.CanBeUsed())
                {
                    mustWrap = _messagesHandler.MessagesTrackers.MessageCompletionTracker.MustInitConnection();
                    encryptedList.Value.Add(messageItem);
                }
                else
                {
                    //These messages will only be sent when TemporaryAuthKey.CanBeUsed is false because for it to be true the connection needs to be Initialized
                    //This way, we're only gonna send this message
                    if (messageItem.Body is BindTempAuthKey)
                    {
                        _messagesHandler.MessagesTrackers.MessageCompletionTracker.ResetInitConnection();
                        encryptedList.Value.Add(messageItem);
                        break;
                    }

                    //Even if we check afterwards, it's better to check here because we'll avoid allocating a List
                    _logger.Verbose("Skipping {Message} because authorization key is not ready (while dequeuing)", messageItem.Body);

                    //Not waking up the loop because it's going to be woken up by the authorization key generation.
                    addBack.Value.Add(messageItem);
                }
            }

            if (addBack.IsValueCreated)
            {
                foreach(var item in addBack.Value)
                {
                    item.SetToSend(wakeUpLoop: false, canDelete: true);
                }
            }

            if (encryptedList.IsValueCreated && encryptedList.Value.Count > 0)
            {
                IObject upperMost;
                MemoryStream? msgSerialization = null;
                List<MessageItem> finalItems;
                List<MessageItem>? containerizedItems = null;
                var seqBef = _mtProtoState.SeqnoHandler.ContentRelatedSent;

                if (encryptedList.Value.Count > 1 && GetContainer(encryptedList.Value, mustWrap, out containerizedItems, out msgSerialization))
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
                    MessageItem message;
                    if (containerizedItems is not null && msgSerialization is not null)
                    {
                        message = containerizedItems[0];
                        finalItems = new List<MessageItem>(1) { message };
                    }
                    else
                    {
                        message = encryptedList.Value[0];
                        finalItems = encryptedList.Value;
                        if (!TrySerialize(message, mustWrap, out msgSerialization))
                        {
                            return;
                        }
                    }
                    
                    if (!_mtProtoState.KeysHandler.TemporaryAuthKey.CanBeUsed() && message.Body is not BindTempAuthKey && message.Body is not MsgsAck)
                    {
                        _logger.Verbose("Postponing {Message} because the authorization key is not ready", message.Body);

                        //Not waking up the loop because it's going to be woken up by the authorization key generation.
                        message.SetToSend(wakeUpLoop: false, canDelete: true);
                        return;
                    }

                    upperMost = message.Body;
                    totalSent++;
                }

                var getAcks = _mtProtoState.Connection.MessagesHandler.MessagesTrackers.AcknowledgementHandler.GetAckMessages();
                foreach (var acks in getAcks)
                {
                    _logger.Information("Sending acknowledgment of {Total} messages", ((MsgsAck)acks.Body).MsgIds.Count);
                    if (TrySerialize(acks, false, out var serialized))
                    {
                        totalSent++;
                        await SendEncryptedAsync(acks.Body, new List<MessageItem>(1) { acks }, serialized);
                        serialized.Dispose();
                    }
                    else
                    {
                        _logger.Error("Failed to serialized msg_ack");
                    }
                }

                await SendEncryptedAsync(upperMost, finalItems, msgSerialization);
                msgSerialization.Dispose();
            }

            _logger.Information("Sent {Count} messages", totalSent);
        }


        public async Task UnencryptedTickAsync(CancellationToken stoppingToken)
        {
            var count = _messagesHandler.MessagesQueue.GetCount(false);
            var totalSent = 0;
            if (count > 0)
            {
                _logger.Verbose("Pulling {Count} unencrypted messages out of queue to send...", count);
                for (var i = 0; i < count; i++)
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

        public async ValueTask SendEncryptedAsync(IObject upperMost, IList<MessageItem> messages, MemoryStream payload)
        {
            var authKey = _mtProtoState.KeysHandler.TemporaryAuthKey.GetCachedKey();
            var sessionId = _mtProtoState.SessionIdHandler.GetSessionId(out _);
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
            using var exportedMessage = encryptedMsg.Export();
            await _connection.Protocol.Writer.SendAsync(exportedMessage);
        }

        public async Task SendUnencryptedAsync(MessageItem messageItem, CancellationToken token)
        {
            if (TrySerialize(messageItem, false, out var serializedBody))
            {
                var messageId = _connection.MtProtoState.MessageIdsHandler.ComputeMessageId();
                using var unencryptedMessage = new UnencryptedConnectionMessage(messageId, serializedBody);
                messageItem.SetProtocolInfo(0, 0);
                messageItem.SetSent(_connection.MessagesDispatcher.GetExecInfo());
                using var unencryptedBody = unencryptedMessage.Export();
                await _connection.Protocol.Writer.SendAsync(unencryptedBody, token);
                _logger.Verbose("Sent unencrypted message");
            }
        }

        public bool TrySerialize(MessageItem item, bool mustWrap, [MaybeNullWhen(false)] out MemoryStream serialized)
        {
            WriteResult trySer;
            var body = item.Body;
            _logger.Verbose("Trying to serialize {Type}", body);
            if (mustWrap && body is not Ping and not GetFutureSalts and not MsgsStateReq and not Pong and not MsgsAck)
            {
                var clientSettings = _mtProtoState.Client.ClientSession.Settings;
                _logger.Information("Wrapping {Type} inside initConnection", item.Body);
                var initConnection = new InitConnection
                {
                    ApiId = clientSettings.ApiSettings.ApiId,
                    AppVersion = clientSettings.ApiSettings.AppVersion,
                    DeviceModel = clientSettings.ApiSettings.DeviceModel,
                    LangCode = clientSettings.ApiSettings.LangCode,
                    LangPack = clientSettings.ApiSettings.LangPack,
                    SystemLangCode = clientSettings.ApiSettings.SystemLangCode,
                    SystemVersion = clientSettings.ApiSettings.SystemVersion,
                    Query = body
                };
                var invokeWithLayer = new InvokeWithLayer(MergedProvider.LayerId, initConnection);
                trySer = invokeWithLayer.ToRecyclableStream(MergedProvider.Singleton, out serialized);
                item.SetProtocolInfo(null, null, true, false);
            }
            else
            {
                trySer = body.ToRecyclableStream(MergedProvider.Singleton, out serialized);
            }

            if (trySer.IsError)
            {
                serialized = null;
                item.SetCompleted(new SerializationFailedError(trySer.GetError().Error), new ExecutionInfo(_mtProtoState.ConnectionInfo));
                return false;
            }

            if(serialized is null)
            {
                //Not necessary as we already check for the result of tryRes, but it's here to suppress the warning
                return false;
            }

            return true;
        }

        public bool GetContainer(List<MessageItem> messageItems, bool mustWrap, out List<MessageItem> containerizedItems, out MemoryStream payload)
        {
            var currentBytes = 0;
            var currentMessagesCount = 0;
            var fineList = new List<Tuple<MessageItem, MemoryStream>>();
            for (var i = 0; i < messageItems.Count; i++)
            {
                var messageItem = messageItems[i];
                if (TrySerialize(messageItem, mustWrap, out var serialized))
                {
                    if (currentBytes + (serialized.Length + 8 + 4 + 4) > ContainerBytesLimit || currentMessagesCount > ContainerMessagesLimit)
                    {
                        if(i == messageItems.Count - 1)
                        {
                            _logger.Information("Returning single message {Body} otherwise no message made it into the container", messageItem.Body);
                            containerizedItems = new List<MessageItem>(1) { messageItem };
                            payload = serialized;
                            return false;
                        }

                        _logger.Information("Postponing {Message} as container size would be too big", messageItem.Body);
                        messageItem.SetToSend();
                        continue;
                    }

                    currentMessagesCount++;
                    currentBytes = (int)serialized.Length + 8 + 4 + 4;
                    fineList.Add(Tuple.Create(messageItem, serialized));
                }
            }

            containerizedItems = fineList.Select(x => x.Item1).ToList();
            var reusableStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
            using var writer = new Writer(MergedProvider.Singleton, reusableStream, true);
            writer.WriteInt32(MsgContainer.ConstructorId);
            writer.WriteInt32(containerizedItems.Count);
            foreach (var item in fineList)
            {
                var messageItem = item.Item1;
                var messageId = _mtProtoState.MessageIdsHandler.ComputeMessageId();
                var seqno = _mtProtoState.SeqnoHandler.ComputeSeqno(messageItem.Body);
                messageItem.SetProtocolInfo(messageId, seqno);
                writer.WriteInt64(messageId);
                writer.WriteInt32(seqno);
                writer.WriteInt32((int)item.Item2.Length);
                item.Item2.CopyTo(writer.Stream);
                item.Item2.Dispose();
            }

            payload = reusableStream;
            return true;
        }

        public override string ToString()
        {
            return $"Send loop";
        }
    }
}