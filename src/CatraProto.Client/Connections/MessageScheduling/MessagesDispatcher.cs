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
using System.Linq;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.MTProto.Deserializers;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations.Interfaces;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.Client.Updates;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;
using Serilog;
namespace CatraProto.Client.Connections.MessageScheduling
{
    internal class MessagesDispatcher
    {
        internal enum ErrorCodes
        {
            MsgIdTooLow = 16,
            MsgIdTooHigh = 17,
            MsgIdMod4 = 18,
            MsgIdCollision = 19,
            MsgIdTooOld = 20,
            SeqNoTooLow = 32,
            SeqNoTooHigh = 33,
            SeqNoNotEven = 34,
            SeqNoNotOdd = 35,
            InvalidContainer = 64
        };

        public UpdatesReceiver? UpdatesHandler { get; set; }
        private readonly Connection _connection;
        private readonly MessagesHandler _messagesHandler;
        private readonly ClientSession _clientSession;
        private readonly MTProtoState _mtProtoState;
        private readonly List<IObjectParser> _parsers;
        private readonly object _mutex = new object();
        private readonly ILogger _logger;
        private bool _startIgnoring;
        public MessagesDispatcher(Connection connection, MessagesHandler messagesHandler, MTProtoState mtProtoState, ClientSession clientSession, ILogger logger)
        {
            _parsers = new List<IObjectParser>(2) { new RpcDeserializer(messagesHandler.MessagesTrackers.MessageCompletionTracker, logger), new MsgContainerDeserializer(logger) };
            _logger = logger.ForContext<MessagesDispatcher>();
            _connection = connection;
            _messagesHandler = messagesHandler;
            _mtProtoState = mtProtoState;
            _clientSession = clientSession;
        }

        public void DispatchMessage(IConnectionMessage connectionMessage, bool protocolError)
        {
            lock (_mutex)
            {
                if (_startIgnoring)
                {
                    _logger.Information("Ignoring received message");
                    return;
                }

                using var reader = new Reader(MergedProvider.Singleton, connectionMessage.Body, false, _parsers);
                if (protocolError)
                {
                    var error = reader.ReadInt32().Value;
                    _logger.Warning("Received protocol error {Error} from server", error);
                    if (error == -404)
                    {
                        if (!_messagesHandler.MessagesTrackers.MessageCompletionTracker.OnNotFoundProtocolError(GetExecInfo()))
                        {
                            _logger.Information("Server forgot authorization key, regenerating...");
                            _connection.RegenKey();
                        }
                    }

                    return;
                }


                var tryRead = reader.ReadObject();
                if (tryRead.IsError)
                {
                    _messagesHandler.MessagesTrackers.AcknowledgementHandler.SendAcknowledgment(connectionMessage.MessageId, null);
                    _logger.Error("Could not deserialize received payload. Error {Error}", tryRead.GetError().Error);
                    return;
                }

                var deserialized = tryRead.Value;
                if (connectionMessage.AuthKeyId != 0)
                {
                    if (IsMessageValid((EncryptedConnectionMessage)connectionMessage, deserialized))
                    {
                        HandleObject(connectionMessage, deserialized, reader);
                    }
                }
                else
                {
                    _logger.Information("Received unencrypted message. id: {MessageId}, body: {Body}", connectionMessage.MessageId, deserialized);
                    HandleObject(connectionMessage, deserialized, reader);
                }
            }
        }

        private bool IsMessageValid(EncryptedConnectionMessage connectionMessage, IObject deserialization)
        {
            using var stream = connectionMessage.GetPlainTextStream(connectionMessage.Padding);
            var msgComputed = connectionMessage.ComputeMsgKey(stream, false);

            if (!msgComputed.SequenceEqual(connectionMessage.MsgKey!))
            {
                _logger.Warning("DISCARDING MESSAGE DUE TO MSG_KEY MISMATCH {ComputeKey} != {ReceivedKey}", msgComputed, connectionMessage.MsgKey);
                _ = _connection.ResetSessionAsync(false);
                return false;
            }

            if (deserialization is not MsgContainer container)
            {
                return InternalCheckMessageValidity(connectionMessage, deserialization);
            }

            foreach (var cMessage in container.Messages)
            {
                // DO NOT DISPOSE
                var newMessage = new EncryptedConnectionMessage(connectionMessage.AuthKey, cMessage.MsgId, connectionMessage.Salt, connectionMessage.SessionId, cMessage.Seqno, null!);
                if (!InternalCheckMessageValidity(newMessage, cMessage.Body))
                {
                    return false;
                }
            }

            return InternalCheckMessageValidity(connectionMessage, deserialization);
        }

        private bool InternalCheckMessageValidity(EncryptedConnectionMessage connectionMessage, IObject deserialized)
        {
            _logger.Information("Received encrypted message. id: {MessageId}, seqno: {Seqno}, session: {SessionId}, salt: {Salt}, body: {Body}", connectionMessage.MessageId, connectionMessage.SeqNo, connectionMessage.SessionId, connectionMessage.Salt, deserialized);
            if (deserialized is BadServerSalt badServerSalt)
            {
                HandleBadServerSalt(badServerSalt, connectionMessage.MessageId);
            }

            if (deserialized is NewSessionCreated newSessionCreated)
            {
                HandleNewSessionCreation(newSessionCreated, connectionMessage.SessionId);
            }

            if (deserialized is BadMsgNotification badMsgNotification)
            {
                HandleBadMsgNotification(badMsgNotification, connectionMessage.MessageId);
            }

            if (_startIgnoring)
            {
                return false;
            }

            var sessionId = _mtProtoState.SessionIdHandler.GetSessionId(out _);
            if (sessionId != connectionMessage.SessionId)
            {
                _logger.Error("Resetting session because local session id {LSession} does not equal to the remote session id {RSession}", sessionId, connectionMessage.SessionId);
                _ = _connection.ResetSessionAsync(false);
                return false;
            }

            if (!_mtProtoState.MessageIdsHandler.CheckMessageIdAge(connectionMessage.MessageId))
            {
                _logger.Information("Resetting session because message id {MessageId} age check failed", connectionMessage.MessageId);
                _ = _connection.ResetSessionAsync(false);
                return false;
            }

            var messageValidity = _mtProtoState.MessageIdsHandler.MessageDuplicateChecker.IsValid(connectionMessage.MessageId);
            if (messageValidity is MessageValidity.Duplicate)
            {
                _logger.Information("Discarding message {Message} because it's a duplicate", connectionMessage.MessageId);
                return false;
            }
            else if (messageValidity is MessageValidity.TooOld)
            {
                _logger.Information("Resetting session because message id {MessageId} is too old", connectionMessage.MessageId);
                _ = _connection.ResetSessionAsync(false);
                return false;
            }

            if (!_mtProtoState.SaltHandler.IsSaltValid(connectionMessage.Salt))
            {
                _logger.Information("Skipping message {MessageId} because it was sent using an invalid salt", connectionMessage.MessageId);
                if(_mtProtoState.SaltHandler.GetSalt() != -1)
                {
                    _logger.Information("Resetting session due to invalid salt");
                    _ = _connection.ResetSessionAsync(false);
                }
                return false;
            }

            //No need to worry about ContainerMessageFailed
            var shouldSeqno = _mtProtoState.SeqnoHandler.ComputeSeqno(deserialized, true);
            if (shouldSeqno == connectionMessage.SeqNo)
            {
                _mtProtoState.SeqnoHandler.ConfirmServerSeqno(deserialized);
            }
            else
            {
                _ = _connection.ResetSessionAsync(false);
                _logger.Error("Received seqno {RSeqno} does not equal computed seqno {CSeqno} ({Obj})", connectionMessage.SeqNo, shouldSeqno, deserialized);
                return false;
            }

            _messagesHandler.MessagesTrackers.AcknowledgementHandler.SendAcknowledgment(connectionMessage.MessageId, deserialized);
            return true;
        }

        private void HandleBadMsgNotification(BadMsgNotification badMsgNotification, long messageId)
        {
            _logger.Error("Received bad_msg_notification with error code {Error} for message {Message}", badMsgNotification.ErrorCode, badMsgNotification.BadMsgId);
            switch (badMsgNotification.ErrorCode)
            {
                case (int)ErrorCodes.MsgIdTooLow:
                case (int)ErrorCodes.MsgIdTooHigh:
                case (int)ErrorCodes.MsgIdTooOld:
                    if (_messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletions(badMsgNotification.BadMsgId, out var messageItems) &&
                        messageItems[0].GetProtocolInfo().upperSeqno!.Value == badMsgNotification.BadMsgSeqno)
                    {
                        _mtProtoState.MessageIdsHandler.SetTimeDifference(MessageIdsHandler.GetSeconds(messageId));
                        _ = _connection.ResetSessionAsync(false);
                    }
                    break;
            }
        }

        private void HandleNewSessionCreation(NewSessionCreated newSessionCreated, long sessionId)
        {
            _mtProtoState.SessionIdHandler.GetSessionId(out var uniqueId);
            if (uniqueId == newSessionCreated.UniqueId)
            {
                return;
            }

            _mtProtoState.SessionIdHandler.SetSessionId(sessionId, newSessionCreated.UniqueId);
            _mtProtoState.SaltHandler.SetSalt(newSessionCreated.ServerSalt);
            _mtProtoState.SeqnoHandler.ContentRelatedReceived = 0;
            _logger.Information("New session created, new server salt {Salt}, new SessionId {SessionId}", newSessionCreated.ServerSalt, sessionId);

            if (_mtProtoState.ConnectionInfo.Main)
            {
                //Not awaiting is fine here. 
                _mtProtoState.Client.UpdatesReceiver.ForceGetDifferenceAllAsync(false);
            }
        }

        private void HandleBadServerSalt(BadServerSalt serverSalt, long messageId)
        {
            _logger.Information("Some messages were sent using the wrong salt, now using the new one ({Salt}) and resending messages", serverSalt.NewServerSalt);
            if (_messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletions(serverSalt.BadMsgId, out var messageItems))
            {
                var seqno = messageItems[0].GetProtocolInfo().upperSeqno!.Value;
                if (seqno != serverSalt.BadMsgSeqno)
                {
                    _logger.Warning("Not applying salt received from BadServerSalt because messageId's ({Id}) seqno is {Actual} not {Received}", serverSalt.BadMsgId, seqno, serverSalt.BadMsgSeqno);
                    return;
                }

                _mtProtoState.SaltHandler.SetSalt(serverSalt.NewServerSalt);
                if (_mtProtoState.MessageIdsHandler.SetTimeDifference(MessageIdsHandler.GetSeconds(messageId)))
                {
                    _logger.Information("Resetting session after time changed on bad_server_salt");
                    _ = _connection.ResetSessionAsync(false, serverSalt.NewServerSalt);
                    return;
                }

                var count = messageItems.Count;
                for (var i = 0; i < count; i++)
                {
                    var item = messageItems[i];
                    _logger.Information("Resending message {Body} because it was sent using an expired salt", item.Body);
                    item.SetToSend(true, i == count - 1, true);
                }
            }
            else
            {
                _logger.Warning("Not applying salt received from BadServerSalt because messageId {Id} was not found", serverSalt.BadMsgId);
            }
        }

        private void HandleObject(IConnectionMessage connectionMessage, IObject obj, Reader reader)
        {
            if (connectionMessage is EncryptedConnectionMessage)
            {
                UpdatesTools.ExtractChats(obj, out var chats, out var users);
                _mtProtoState.Client.DatabaseManager.UpdateChats(chats, users);
                UpdatesTools.OnFileReceived(obj, obj, false);

                switch (obj)
                {
                    case MsgsStateInfo msgsStateInfo:
                        _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(msgsStateInfo.ReqMsgId, msgsStateInfo, GetExecInfo());
                        break;
                    case Ping ping:
                        HandlePing(ping);
                        break;
                    case Pong pong:
                        _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(pong.MsgId, pong, GetExecInfo());
                        break;
                    case MsgsAck msgsAck:
                        var getExecInfo = GetExecInfo(false);
                        foreach (var id in msgsAck.MsgIds)
                        {
                            _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetAsAcknowledged(id, getExecInfo);
                        }

                        break;
                    case FutureSalts futureSalts:
                        _mtProtoState.SaltHandler.AddReceivedSalts(futureSalts);
                        _messagesHandler.MessagesTrackers.MessageCompletionTracker.GetMessageCompletion(futureSalts.ReqMsgId, out var item, true);
                        item?.SetCompleted(futureSalts, GetExecInfo(false));
                        break;
                    case RpcResult rpcResult:
                        HandleRpcResult(connectionMessage, obj, reader, rpcResult);
                        break;
                    case MsgContainer msgContainer:
                        foreach (var message in msgContainer.Messages)
                        {
                            HandleObject(connectionMessage, message.Body, reader);
                        }

                        break;
                    case UpdatesBase updatesBase:
                        UpdatesHandler?.OnNewUpdates(updatesBase);
                        break;
                    case UpdateBase updateBase:
                        UpdatesHandler?.OnNewUpdates(updateBase);
                        break;
                    case BadMsgNotification:
                    case NewSessionCreated:
                    case BadServerSalt:
                        break;
                    default:
                        _logger.Information("Received object {Obj}", obj.ToJson());
                        break;
                }
            }
            else
            {
                _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(0, obj, GetExecInfo());
            }
        }

        private void HandlePing(Ping ping)
        {
            _logger.Information("Replying to ping from server with Id {Id}", ping);
            _messagesHandler.MessagesQueue.EnqueueMessage(new Pong
            {
                PingId = ping.PingId
            }, new MessageSendingOptions(true), null, out _, default);
        }

        private void HandleRpcResult(IConnectionMessage connectionMessage, IObject obj, Reader reader, RpcResult rpcObject)
        {
            _logger.Information("Handling rpc message in response to id {Id}", rpcObject.ReqMsgId);
            if (!_messagesHandler.MessagesTrackers.MessageCompletionTracker.GetRpcMethod(rpcObject.ReqMsgId, out var method))
            {
                _logger.Error("Not handling RPC message {Id} in reply to {ReplyTo} because it was not found in the list of sent RPC queries", connectionMessage.MessageId, rpcObject.ReqMsgId);
                return;
            }

            if (rpcObject.Result is MTProto.Rpc.Interfaces.RpcError error)
            {
                if (error is IMigrateError migrateError)
                {
                    if (_messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(rpcObject.ReqMsgId, out var item))
                    {
                        _logger.Information("Received migrate error, moving request and setting account dc to DC{DcId} ", migrateError.DcId);
                        Task.Run(async () =>
                        {
                            try
                            {
                                await using var connection = await _clientSession.ConnectionPool.GetConnectionByDcAsync(migrateError.DcId, false, false, item.CancellationToken);
                                await _clientSession.ConnectionPool.SetAccountConnectionAsync(connection.Connection, true);
                                item.BindTo(connection.Connection.MessagesHandler, true);
                                item.SetToSend();
                            }
                            catch (Exception e) when (e is not OperationCanceledException)
                            {
                                _logger.Error("Caught exception while migrating request", e);
                            }
                        });
                    }
                    return;
                }

                _mtProtoState.Client.LoginManager.OnErrorReceived(error, method);
            }
            else
            {
                if (rpcObject.Result is IObject iObj)
                {
                    UpdatesTools.ExtractChats(iObj, out var chats, out var users);
                    _mtProtoState.Client.DatabaseManager.UpdateChats(chats, users);
                    UpdatesTools.OnFileReceived(iObj, method, method is not GetDifference or GetChannelDifference or Client.TL.Schemas.CloudChats.Message);
                    switch (iObj)
                    {
                        case TL.Schemas.CloudChats.Users.UserFull uFull:
                            _mtProtoState.Client.DatabaseManager.PeerDatabase.PushChatToDb(uFull.FullUser);
                            break;
                        case TL.Schemas.CloudChats.Messages.ChatFull cFull:
                            _mtProtoState.Client.DatabaseManager.PeerDatabase.PushChatToDb(cFull.FullChat);
                            break;
                        case UpdatesBase update:
                            UpdatesHandler?.OnNewUpdates(update, method);
                            break;
                    }
                }
            }

            _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(rpcObject.ReqMsgId, rpcObject.Result, GetExecInfo(true));
        }

        public void IgnoreMessages(bool ignore)
        {
            lock (_mutex)
            {
                _startIgnoring = ignore;
            }
        }

        public ExecutionInfo GetExecInfo(bool rpcTelegram = false)
        {
            return new ExecutionInfo(_mtProtoState.Connection.ConnectionInfo, rpcTelegram);
        }
    }
}