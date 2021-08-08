using System;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    class MessagesValidator
    {
        private readonly MessagesHandler _messagesHandler;
        private readonly MTProtoState _mtProtoState;
        private readonly ILogger _logger;

        public MessagesValidator(MessagesHandler messagesHandler, MTProtoState mtProtoState, ILogger logger)
        {
            _logger = logger.ForContext<MessagesValidator>();
            _mtProtoState = mtProtoState;
            _messagesHandler = messagesHandler;
        }

        public bool IsMessageValid(EncryptedConnectionMessage connectionMessage, IObject deserialization)
        {
            if (deserialization is not MsgContainer container)
            {
                return InternalCheckMessageValidity(connectionMessage, deserialization);
            }

            foreach (var cMessage in container.Messages)
            {
                var newMessage = new EncryptedConnectionMessage(connectionMessage.AuthKey, cMessage.MsgId, connectionMessage.Salt, connectionMessage.SessionId, cMessage.Seqno, Array.Empty<byte>());
                if (!InternalCheckMessageValidity(newMessage, cMessage.Body))
                {
                    return false;
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
    }
}