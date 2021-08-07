using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.Extensions;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Deserializers;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    class MessagesDispatcher
    {
        private readonly MessagesHandler _messagesHandler;
        private readonly RpcDeserializer _rpcDeserializer;
        private readonly MTProtoState _mtProtoState;
        private readonly ILogger _logger;

        public MessagesDispatcher(MessagesHandler messagesHandler, MTProtoState mtProtoState, ILogger logger)
        {
            _rpcDeserializer = new RpcDeserializer(messagesHandler.MessagesTrackers.MessageCompletionTracker, logger);
            _logger = logger.ForContext<MessagesDispatcher>();
            _messagesHandler = messagesHandler;
            _mtProtoState = mtProtoState;
        }

        public void DispatchMessage(IConnectionMessage connectionMessage)
        {
            var reader = new Reader(MergedProvider.Singleton, connectionMessage.Body.ToMemoryStream());
            reader.AddCustomObjectDeserializer(typeof(RpcObject), _rpcDeserializer);

            if (connectionMessage.Body.Length == 4)
            {
                var error = reader.Read<int>();
                var rpcError = new RpcError
                {
                    ErrorCode = error,
                    ErrorMessage = "Protocol error"
                };

                _logger.Warning("Received protocol error {Error} from server", error);
                _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(0, rpcError);
                return;
            }

            try
            {
                var deserialized = reader.Read<IObject>();
                _logger.Information("Handling message of type {T}", deserialized);
                if (connectionMessage.AuthKeyId != 0)
                {
                    if (deserialized is GzipPacked gzipPacked)
                    {
                        reader.Dispose();
                        reader = new Reader(MergedProvider.Singleton, GzipHandler.ReadGzipPacket(gzipPacked.PackedData));
                        deserialized = reader.Read<IObject>();
                    }

                    if (CheckMessageValidity((EncryptedConnectionMessage)connectionMessage, deserialized))
                    {
                        HandleObject(deserialized, reader, true);
                    }
                }
                else
                {
                    HandleObject(deserialized, reader, false);
                }
            }
            catch (DeserializationException e)
            {
                _logger.Error(e, "Failed to deserialize received message");
            }

            reader.Dispose();
        }

        private bool CheckMessageValidity(EncryptedConnectionMessage connectionMessage, IObject deserialization)
        {
            if (deserialization is MsgContainer container)
            {
                foreach (var cMessage in container.Messages)
                {
                    var newMessage = new EncryptedConnectionMessage(connectionMessage.AuthKey, cMessage.MsgId, connectionMessage.Salt, connectionMessage.SessionId, cMessage.Seqno, Array.Empty<byte>());
                    if (!InternalCheckMessageValidity(newMessage, cMessage.Body))
                    {
                        return false;
                    }
                }
            }

            return InternalCheckMessageValidity(connectionMessage, deserialization);
        }

        private bool InternalCheckMessageValidity(EncryptedConnectionMessage connectionMessage, IObject deserialized)
        {
            if (!_mtProtoState.MessageIdsHandler.CheckMessageId(connectionMessage.MessageId))
            {
                return false;
            }

            var shouldSeqno = _mtProtoState.SeqnoHandler.ComputeSeqno(deserialized, true);
            if (shouldSeqno != connectionMessage.SeqNo)
            {
                _logger.Warning("Received seqno {RSeqno} does not equal computed seqno {CSeqno} ({Obj})", connectionMessage.SeqNo, shouldSeqno, deserialized);
            }

            switch (deserialized)
            {
                case NewSessionCreated newSessionCreated:
                    HandleNewSessionCreation(newSessionCreated, connectionMessage.SessionId);
                    break;
                case BadServerSalt badServerSalt:
                    HandleBadServerSalt(badServerSalt);
                    break;
            }

            var sessionId = _mtProtoState.SessionIdHandler.GetSessionId();
            if (sessionId != connectionMessage.SessionId)
            {
                _logger.Warning("Local session {LSession} is not equal to the remote session {RSession}", sessionId, connectionMessage.SessionId);
                return false;
            }

            if (!_mtProtoState.SaltHandler.IsSaltValid(connectionMessage.Salt))
            {
                return false;
            }

            if (connectionMessage.AuthKeyId != 0)
            {
                _messagesHandler.MessagesTrackers.MessagesAckTracker.AcknowledgeNext(deserialized, connectionMessage.MessageId);
            }

            return true;
        }

        private void HandleObject(IObject obj, Reader reader, bool isEncrypted)
        {
            if (isEncrypted)
            {
                switch (obj)
                {
                    case FutureSalts futureSalts:
                        HandleFutureSalts(futureSalts);
                        break;
                    case RpcObject rpcResult:
                        HandleRpcResult(rpcResult);
                        break;
                    case MsgContainer msgContainer:
                        HandleContainer(msgContainer, reader);
                        break;
                    case UUpdates updates:
                        var random = new Random();
                        foreach (var t in updates.Updates)
                        {
                            var update = (UpdateNewMessage)t;
                            var randomInt = random.Next();
                            _ = _mtProtoState.Api.CloudChatsApi.Messages.SendMessageAsync(new InputPeerUser
                            {
                                AccessHash = ((User)updates.Users[0]).AccessHash!.Value,
                                UserId = updates.Users[0].Id
                            }, "This is a reply", randomInt, replyToMsgId: update.Message.Id).ContinueWith(x =>
                            {
                                if (x.Result.RpcCallFailed)
                                {
                                    JsonSerializer.Serialize(x.Result.Error);
                                }
                            }, TaskContinuationOptions.OnlyOnRanToCompletion);
                        }

                        break;
                    default:
                        _logger.Warning("Couldn't handle message of type {obj}", obj);
                        break;
                }
            }
            else
            {
                _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(0, obj);
            }
        }

        private void HandleNewSessionCreation(NewSessionCreated newSessionCreated, long sessionId)
        {
            if (_mtProtoState.SessionIdHandler.GetSessionId() == sessionId)
            {
                _logger.Warning("Received new session created but the id is the same as the old one, new server salt {Salt}, new SessionId {SessionId}", newSessionCreated.ServerSalt, sessionId);
                return;
            }

            _mtProtoState.SessionIdHandler.SetSessionId(sessionId);
            _mtProtoState.SaltHandler.SetSalt(newSessionCreated.ServerSalt, true);
            _mtProtoState.SeqnoHandler.ContentRelatedReceived = 0;
            _logger.Information("New session created, new server salt {Salt}, new SessionId {SessionId}", newSessionCreated.ServerSalt, sessionId);
        }

        private void HandleBadServerSalt(BadServerSalt serverSalt)
        {
            _mtProtoState.SaltHandler.SetSalt(serverSalt.NewServerSalt, false);
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
            _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(futureSalts.ReqMsgId, futureSalts);
        }

        private void HandleRpcResult(RpcObject rpcObject)
        {
            _logger.Information("Handling rpc message in response to id {Id}", rpcObject.MessageId);
            _messagesHandler.MessagesTrackers.MessageCompletionTracker.SetCompletion(rpcObject.MessageId, rpcObject.Response);
        }
    }
}