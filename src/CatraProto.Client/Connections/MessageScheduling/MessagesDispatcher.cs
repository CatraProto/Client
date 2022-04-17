using System.Collections.Generic;
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
        public UpdatesReceiver? UpdatesHandler { get; set; }
        private readonly MessagesValidator _messagesValidator;
        private readonly Connection _connection;
        private readonly MessagesHandler _messagesHandler;
        private readonly ClientSession _clientSession;
        private readonly MTProtoState _mtProtoState;
        private readonly List<IObjectParser> _parsers;
        private readonly ILogger _logger;

        public MessagesDispatcher(Connection connection, MessagesHandler messagesHandler, MTProtoState mtProtoState, ClientSession clientSession)
        {
            _messagesValidator = new MessagesValidator(messagesHandler, mtProtoState, clientSession.Logger);
            _parsers = new List<IObjectParser>(1) { new RpcDeserializer(messagesHandler.MessagesTrackers.MessageCompletionTracker, clientSession.Logger) };
            _logger = clientSession.Logger.ForContext<MessagesDispatcher>();
            _connection = connection;
            _messagesHandler = messagesHandler;
            _mtProtoState = mtProtoState;
            _clientSession = clientSession;
        }

        public void DispatchMessage(IConnectionMessage connectionMessage)
        {
            using var reader = new Reader(MergedProvider.Singleton, connectionMessage.Body.ToMemoryStream(), false, _parsers);
            if (connectionMessage.Body.Length == 4)
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
                _logger.Error("Could not deserialized received payload. Error {Error}", tryRead.GetError().Error);
                return;
            }

            var deserialized = tryRead.Value;
            _logger.Information("Handling message of type {T}", deserialized);
            if (connectionMessage.AuthKeyId != 0)
            {
                if (_messagesValidator.IsMessageValid((EncryptedConnectionMessage)connectionMessage, deserialized))
                {
                    HandleObject(connectionMessage, deserialized, reader);
                }
            }
            else
            {
                HandleObject(connectionMessage, deserialized, reader);
            }
        }

        private void HandleObject(IConnectionMessage connectionMessage, IObject obj, Reader reader)
        {
            if (connectionMessage is EncryptedConnectionMessage)
            {
                UpdatesTools.ExtractChats(obj, out var chats, out var users);
                _mtProtoState.Client.DatabaseManager.UpdateChats(chats, users);

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
                        var getExecInfo = GetExecInfo();
                        foreach (var id in msgsAck.MsgIds)
                        {
                            _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetAsAcknowledged(id, getExecInfo);
                        }

                        break;
                    case FutureSalts futureSalts:
                        _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(futureSalts.ReqMsgId, futureSalts, GetExecInfo());
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
            if (rpcObject.Result is MTProto.Rpc.Interfaces.RpcError error)
            {
                if (error is IMigrateError migrateError)
                {
                    Task.Run(async () =>
                    {
                        if (_messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(rpcObject.ReqMsgId, out var item))
                        {
                            _logger.Information("Received migrate error, moving request and setting account dc to DC{DcId} ", migrateError.DcId);
                            //TODO: Support cancellation
                            await using var connection = await _clientSession.ConnectionPool.GetConnectionByDcAsync(migrateError.DcId, false, false, System.Threading.CancellationToken.None);
                            await _clientSession.ConnectionPool.SetAccountConnectionAsync(connection.Connection, true);
                            item.BindTo(connection.Connection.MessagesHandler);
                            item.SetToSend();
                        }
                    });
                    return;
                }
            }


            if (_messagesHandler.MessagesTrackers.MessageCompletionTracker.GetRpcMethod(rpcObject.ReqMsgId, out var method))
            {
                if (rpcObject.Result is IObject iObj)
                {
                    UpdatesTools.ExtractChats(iObj, out var chats, out var users);
                    _mtProtoState.Client.DatabaseManager.UpdateChats(chats, users);
                    switch (rpcObject.Result)
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

                _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(rpcObject.ReqMsgId, rpcObject.Result, GetExecInfo(true));
            }
        }

        public ExecutionInfo GetExecInfo(bool rpcTelegram = false)
        {
            return new ExecutionInfo(_mtProtoState.Connection.ConnectionInfo, rpcTelegram);
        }
    }
}