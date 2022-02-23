using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.MTProto.Deserializers;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Parsers;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations.Interfaces;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.Client.Updates;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    class MessagesDispatcher
    {
        public UpdatesReceiver? UpdatesHandler { get; set; }
        private readonly MessagesValidator _messagesValidator;
        private readonly Connection _connection;
        private readonly MessagesHandler _messagesHandler;
        private readonly RpcDeserializer _rpcDeserializer;
        private readonly ClientSession _clientSession;
        private readonly MTProtoState _mtProtoState;
        private readonly ILogger _logger;

        public MessagesDispatcher(Connection connection, MessagesHandler messagesHandler, MTProtoState mtProtoState, ClientSession clientSession)
        {
            _rpcDeserializer = new RpcDeserializer(messagesHandler.MessagesTrackers.MessageCompletionTracker, clientSession.Logger);
            _messagesValidator = new MessagesValidator(messagesHandler, mtProtoState, clientSession.Logger);
            _logger = clientSession.Logger.ForContext<MessagesDispatcher>();
            _connection = connection;
            _messagesHandler = messagesHandler;
            _mtProtoState = mtProtoState;
            _clientSession = clientSession;
        }

        public void DispatchMessage(IConnectionMessage connectionMessage)
        {
            using var reader = new Reader(MergedProvider.Singleton, connectionMessage.Body.ToMemoryStream());
            reader.SetRpcDeserializer(_rpcDeserializer);
            if (connectionMessage.Body.Length == 4)
            {
                var error = reader.Read<int>();
                _logger.Warning("Received protocol error {Error} from server", error);
                if (error == -404)
                {
                    _messagesHandler.MessagesTrackers.MessageCompletionTracker.OnNotFoundProtocolError(GetExecInfo());
                    _logger.Information("Server forgot authorization key, regenerating...");
                    _connection.RegenKey();
                }

                return;
            }

            try
            {
                var deserialized = reader.Read<IObject>();
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
            catch (DeserializationException e)
            {
                _logger.Error(e, "Failed to deserialize received message");
            }
        }

        private void HandleObject(IConnectionMessage connectionMessage, IObject obj, Reader reader)
        {
            if (connectionMessage is EncryptedConnectionMessage encryptedConnectionMessage)
            {
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
                    case RpcObject rpcResult:
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

        private void HandleRpcResult(IConnectionMessage connectionMessage, IObject obj, Reader reader, RpcObject rpcObject)
        {
            _logger.Information("Handling rpc message in response to id {Id}", rpcObject.MessageId);
            if (rpcObject.Response is RpcError error)
            {
                var errorDetected = ParsersList.GetError(error);
                if (errorDetected is IMigrateError migrateError)
                {
                    Task.Run(async () =>
                    {
                        if (_messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(rpcObject.MessageId, out var item))
                        {
                            _logger.Information("Received migrate error, moving request and setting account dc to DC{DcId} ", migrateError.DcId);
                            var connection = await _clientSession.ConnectionPool.GetConnectionByDcAsync(migrateError.DcId);
                            _clientSession.ConnectionPool.SetAccountConnection(connection);
                            item.BindTo(connection.MessagesHandler);
                            item.SetToSend();
                        }
                    });
                    return;
                }
            }


            if (_messagesHandler.MessagesTrackers.MessageCompletionTracker.GetRpcMethod(rpcObject.MessageId, out var method))
            {
                if (rpcObject.Response is UpdatesBase update)
                {
                    UpdatesHandler?.OnNewUpdates(update, method);
                }

                _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(rpcObject.MessageId, rpcObject.Response, GetExecInfo());
            }
        }

        public ExecutionInfo GetExecInfo()
        {
            return new ExecutionInfo(_mtProtoState.Connection.ConnectionInfo);
        }
    }
}