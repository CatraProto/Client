using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.Extensions;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;
using Serilog;
using EncryptedMessage = CatraProto.Client.Connections.Messages.EncryptedMessage;

namespace CatraProto.Client.MTProto
{
    class MessagesDispatcher
    {
        private ConnectionState _connectionState;
        private RpcDeserializer _rpcDeserializer;
        private ILogger _logger;

        public MessagesDispatcher(ConnectionState connectionState, ILogger logger)
        {
            _logger = logger.ForContext<MessagesDispatcher>();
            _connectionState = connectionState;
            _rpcDeserializer = new RpcDeserializer(_connectionState.MessagesHandler, logger);
        }

        public void DispatchMessage(IMessage message)
        {
            var reader = new Reader(MergedProvider.Singleton, message.Body.ToMemoryStream());
            reader.AddCustomObjectDeserializer(typeof(RpcObject), _rpcDeserializer);
            if (message.Body.Length == 4)
            {
                var error = reader.Read<int>();
                var rpcError = new RpcError
                {
                    ErrorCode = error,
                    ErrorMessage = "Protocol error"
                };

                _logger.Warning("Received protocol error {Error} from server", error);
                _connectionState.MessagesHandler.SetMessageResult(0, rpcError);
                return;
            }

            try
            {
                var deserialized = reader.Read<IObject>();
                
                _logger.Information("Handling message of type {T}", deserialized);
                if (message.AuthKeyId != 0)
                {
                    if (deserialized is GzipPacked gzipPacked)
                    {
                        reader.Dispose();
                        reader = new Reader(MergedProvider.Singleton, GzipHandler.ReadGzipPacket(gzipPacked.PackedData));
                        deserialized = reader.Read<IObject>();
                    }
                    
                    if (CheckMessageValidity((EncryptedMessage)message, deserialized))
                    {
                        HandleObject(deserialized, reader, message.AuthKeyId == 0);
                    }
                }
                else
                {
                    HandleObject(deserialized, reader, message.AuthKeyId == 0);
                }
                reader.Dispose();
            }
            catch (DeserializationException e)
            {
                _logger.Error(e, "Failed to deserialize received message");
            }
        }

        private bool CheckMessageValidity(EncryptedMessage message, IObject deserialization)
        {
            if (deserialization is MsgContainer container)
            {
                foreach (var cmessage in container.Messages)
                {
                    var newMessage = new EncryptedMessage
                    {
                        AuthKeyId = message.AuthKeyId,
                        MessageId = cmessage.MsgId,
                        Salt = message.Salt,
                        SessionId = message.SessionId,
                        SeqNo = cmessage.Seqno
                    };

                    if (!InternalCheckMessageValidity(newMessage, cmessage.Body))
                    {
                        return false;
                    }
                }
            }

            return InternalCheckMessageValidity(message, deserialization);
        }

        private bool InternalCheckMessageValidity(EncryptedMessage message, IObject serialized)
        {
            if (serialized is NewSessionCreated newSessionCreated)
            {
                HandleNewSessionCreation(newSessionCreated, message.SessionId);
            }
            
            if (!_connectionState.MessageIdsHandler.CheckMessageId(message.MessageId))
            {
                return false;
            }
            
            var salt = _connectionState.SaltHandler.GetSalt();
            if (salt != message.Salt)
            {
                _logger.Warning("Received salt {RSalt} does not equal local salt {LSalt}", message.Salt, salt);
                return false;
            }

            var shouldSeqno = _connectionState.SeqnoHandler.ComputeSeqno(serialized, true);
            if (shouldSeqno != message.SeqNo)
            {
                _logger.Warning("Received seqno {RSeqno} does not equal computed seqno {CSeqno} ({Obj})", message.SeqNo, shouldSeqno, serialized);
                //return false;
            }
            
            return true;
        }

        private void HandleNewSessionCreation(NewSessionCreated newSessionCreated, long sessionId)
        {
            _connectionState.SaltHandler.SetSalt(newSessionCreated.ServerSalt);
            _connectionState.SessionIdHandler.SetSessionId(sessionId);
            _connectionState.SeqnoHandler.ContentRelatedReceived = 0;
            _logger.Information("New session created, new server salt {Salt}, new SessionId {SessionId}", newSessionCreated.ServerSalt, sessionId);
        }
        
        private void HandleObject(IObject obj, Reader reader, bool isUnencrypted)
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
                default:
                    if (isUnencrypted)
                    {
                        if (_connectionState.MessagesHandler.GetMethod(0, out var method))
                        {
                            var nextType = obj.GetType();
                            if (nextType == typeof(IList<>) && method.IsVector || nextType == method.Type || nextType.IsSubclassOf(method.Type))
                            {
                                _connectionState.MessagesHandler.SetMessageResult(0, obj);
                            }
                        }
                    }
                    else if (obj is UUpdates updates)
                    {
                        var random = new Random();
                        for (var i = 0; i < updates.Updates.Count; i++)
                        {
                            var update = (UpdateNewMessage)updates.Updates[i];
                            var randomInt = random.Next();
                            _ = _connectionState.Api.CloudChatsApi.Messages.SendMessageAsync(new InputPeerUser()
                            {
                                AccessHash = ((User)updates.Users[0]).AccessHash.Value,
                                UserId = updates.Users[0].Id
                            }, "This is a reply", randomInt, replyToMsgId: update.Message.Id).ContinueWith(x =>
                            {
                                if (x.Result.RpcCallFailed)
                                {
                                    JsonSerializer.Serialize(x.Result.Error);
                                }
                            }, TaskContinuationOptions.OnlyOnRanToCompletion);
                            _ = _connectionState.Api.CloudChatsApi.Users.GetUsersAsync(new List<InputUserBase>()
                            {
                                new InputUser()
                                {
                                    AccessHash = ((User)updates.Users[0]).AccessHash.Value,
                                    UserId = ((User)updates.Users[0]).Id
                                }
                            }).ContinueWith(x => _logger.Information(JsonSerializer.Serialize<object>(x.Result.Response), TaskContinuationOptions.OnlyOnRanToCompletion));
                        }
                    }
                    else
                    {
                        _logger.Information($"Couldn't handle message of type {obj}");
                        _logger.Information(JsonSerializer.Serialize(obj));
                    }

                    break;
            }
        }

        private void HandleContainer(MsgContainer container, Reader reader)
        {
            foreach (var message in container.Messages)
            {
                HandleObject(message.Body, reader, false);
            }
        }

        private void HandleFutureSalts(FutureSalts futureSalts)
        {
            _connectionState.MessagesHandler.SetMessageResult(futureSalts.ReqMsgId, futureSalts);
        }

        private void HandleRpcResult(RpcObject rpcObject)
        {
            _logger.Information("Handling rpc message in response to id {Id}", rpcObject.MessageId);
            _connectionState.MessagesHandler.SetMessageResult(rpcObject.MessageId, rpcObject.Response);

        }
    }
}