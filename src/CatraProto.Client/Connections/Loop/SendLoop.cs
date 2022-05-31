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
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
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
            var encryptedList = new Lazy<List<MessageItem>>(() => new List<MessageItem>(1));
            var getAcks = _mtProtoState.Connection.MessagesHandler.MessagesTrackers.AcknowledgementHandler.GetAckMessages();

            foreach (var x in getAcks)
            {
                x.BindTo(_connection.MessagesHandler);
                encryptedList.Value.Add(x);
            }

            var count = _messagesHandler.MessagesQueue.GetCount(true);
            var totalSent = 0;
            if (count > 0)
            {
                var mustWrap = false;
                _logger.Verbose("Pulling {Count} encrypted messages out of queue to send...", count);
                for (var i = 0; i < count; i++)
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

                    if (messageItem.Body is MsgsStateReq)
                    {
                        encryptedList.Value.Add(messageItem);
                        break;
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
                        if (TrySerialize(message, mustWrap, out msgSerialization))
                        {
                            if (!_mtProtoState.KeysHandler.TemporaryAuthKey.CanBeUsed() && message.Body is not BindTempAuthKey && message.Body is not MsgsAck)
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
                    else if (GetContainer(encryptedList.Value, mustWrap, out var containerizedItems, out msgSerialization))
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

                _logger.Information("Sent {Count} messages", totalSent);
            }
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

        public async Task SendEncryptedAsync(IObject upperMost, IList<MessageItem> messages, byte[] payload)
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
            await _connection.Protocol.Writer.SendAsync(encryptedMsg.Export());
        }

        public async Task SendUnencryptedAsync(MessageItem messageItem, CancellationToken token)
        {
            if (TrySerialize(messageItem, false, out var serializedBody))
            {
                var messageId = _connection.MtProtoState.MessageIdsHandler.ComputeMessageId();
                var unencryptedMessage = new UnencryptedConnectionMessage(messageId, serializedBody);
                messageItem.SetProtocolInfo(0, 0);
                messageItem.SetSent(_connection.MessagesDispatcher.GetExecInfo());
                var unencryptedBody = unencryptedMessage.Export();
                await _connection.Protocol.Writer.SendAsync(unencryptedBody, token);
                _logger.Verbose("Sent unencrypted message");
            }
        }

        public bool TrySerialize(MessageItem item, bool mustWrap, [MaybeNullWhen(false)] out byte[] serialized)
        {
            var body = item.Body;
            _logger.Verbose("Trying to serialize {Type}", body);
            WriteResult trySer;
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
                trySer = invokeWithLayer.ToArray(MergedProvider.Singleton, out serialized);
                item.SetProtocolInfo(null, null, true, false);
            }
            else
            {
                trySer = body.ToArray(MergedProvider.Singleton, out serialized);
            }

            if (trySer.IsError)
            {
                serialized = null;
                item.SetCompleted(new SerializationFailed(trySer.GetError().Error), new ExecutionInfo(_mtProtoState.ConnectionInfo));
                return false;
            }

            return true;
        }

        public bool GetContainer(List<MessageItem> messageItems, bool mustWrap, [MaybeNullWhen(false)] out List<MessageItem> containerizedItems, [MaybeNullWhen(false)] out byte[] container)
        {
            var currentBytes = 0;
            var currentMessagesCount = 0;
            var fineList = new List<Tuple<MessageItem, byte[]>>();
            foreach (var messageItem in messageItems)
            {
                if (TrySerialize(messageItem, mustWrap, out var serialized))
                {
                    if (currentBytes + (serialized.Length + 8 + 4 + 4) > ContainerBytesLimit || currentMessagesCount > ContainerMessagesLimit)
                    {
                        _logger.Information("Postponing {Message} as container size would be too big", messageItem.Body);
                        messageItem.SetToSend();
                        continue;
                    }

                    currentMessagesCount++;
                    currentBytes = serialized.Length + 8 + 4 + 4;
                    fineList.Add(Tuple.Create(messageItem, serialized));
                }
            }

            if (fineList.Count == 0)
            {
                _logger.Verbose("No message made it into the container");
                containerizedItems = null;
                container = null;
                return false;
            }

            containerizedItems = fineList.Select(x => x.Item1).ToList();

            using var writer = new Writer(MergedProvider.Singleton, new MemoryStream());
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
                writer.WriteInt32(item.Item2.Length);
                writer.Stream.Write(item.Item2);
            }

            container = ((MemoryStream)writer.Stream).ToArray();
            return true;
        }

        public override string ToString()
        {
            return $"Send loop";
        }
    }
}