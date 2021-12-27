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
using CatraProto.Client.TL.Schemas.CloudChats.Help;
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
        public UpdatesHandler? UpdatesHandler { get; set; }
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

        public async Task DispatchMessage(IConnectionMessage connectionMessage)
        {
            using var reader = new Reader(MergedProvider.Singleton, connectionMessage.Body.ToMemoryStream());
            reader.SetRpcDeserializer(_rpcDeserializer);
            if (connectionMessage.Body.Length == 4)
            {
                var error = reader.Read<int>();
                var rpcError = new RpcError
                {
                    ErrorCode = error,
                    ErrorMessage = "Protocol error"
                };

                //It could also be an error during the key exchange, but if everything is implemented correctly it should never happen
                _logger.Warning("Received protocol error {Error} from server", error);


                _logger.Information("Server forgot authorization key, regenerating and rescheduling messages");
                _mtProtoState.KeysHandler.TemporaryAuthKey.SetExpired();
                await _connection.RegenKey();
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
                        await HandleObject(deserialized, reader, true);
                    }
                }
                else
                {
                    await HandleObject(deserialized, reader, false);
                }
            }
            catch (DeserializationException e)
            {
                _logger.Error(e, "Failed to deserialize received message");
            }
        }

        private async Task HandleObject(IObject obj, Reader reader, bool isEncrypted)
        {
            if (isEncrypted)
            {
                switch (obj)
                {
                    case Ping ping:
                        HandlePing(ping);
                        break;
                    case Pong pong:
                        HandlePong(pong);
                        break;
                    case MsgsAck msgsAck:
                        _messagesHandler.MessagesTrackers.MessagesAckTracker.ServerSentAcks(msgsAck, GetExecInfo());
                        break;
                    case FutureSalts futureSalts:
                        HandleFutureSalts(futureSalts);
                        break;
                    case RpcObject rpcResult:
                        await HandleRpcResult(rpcResult);
                        break;
                    case MsgContainer msgContainer:
                        HandleContainer(msgContainer, reader);
                        break;
                    case UpdatesBase updatesBase:
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

        private void HandlePong(Pong pong)
        {
            _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(pong.MsgId, pong, GetExecInfo());
        }

        private void HandleContainer(MsgContainer container, Reader reader)
        {
            foreach (var message in container.Messages)
            {
                HandleObject(message.Body, reader, true);
            }
        }

        private void HandleFutureSalts(FutureSalts futureSalts)
        {
            _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(futureSalts.ReqMsgId, futureSalts, GetExecInfo());
        }

        private async Task HandleRpcResult(RpcObject rpcObject)
        {
            _logger.Information("Handling rpc message in response to id {Id}", rpcObject.MessageId);
            if (rpcObject.Response is RpcError error)
            {
                var errorDetected = ParsersList.GetError(error);
                if (errorDetected is IMigrateError migrateError)
                {
                    if (_messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(rpcObject.MessageId, out var item))
                    {
                        _logger.Information("Received migrate error, moving request and setting account dc to DC{DcId} ", migrateError.DcId);
                        var connection = await _clientSession.ConnectionPool.GetConnectionByDcAsync(migrateError.DcId);
                        _clientSession.ConnectionPool.SetAccountConnection(connection);
                        item.BindTo(connection.MessagesHandler);
                        item.SetToSend();
                        return;
                        //item.BindTo((await _connectionPool.GetConnectionByDcAsync(migrateError.DcId)).MessagesHandler);
                    }
                }
            }

            _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(rpcObject.MessageId, rpcObject.Response, GetExecInfo());
        }

        private ExecutionInfo GetExecInfo()
        {
            return new ExecutionInfo(_mtProtoState.Connection.ConnectionInfo);
        }
    }
}