using System;
using System.Diagnostics;
using System.Linq;
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
            using var stream = connectionMessage.GetPlainTextStream(connectionMessage.Padding);
            var msgComputed = connectionMessage.ComputeMsgKey(stream.ToArray(), false);
            
            if (!msgComputed.SequenceEqual(connectionMessage.MsgKey!))
            {
                _logger.Warning("DISCARDING MESSAGE DUE TO MSG_KEY MISMATCH {ComputeKey} != {ReceivedKey}", msgComputed, connectionMessage.MsgKey);
                return false;
            }
            
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
            
            var sessionId = _mtProtoState.SessionIdHandler.GetSessionId();
            if (sessionId != connectionMessage.SessionId)
            {
                _logger.Warning("Local session {LSession} does not equal to the remote session {RSession}", sessionId, connectionMessage.SessionId);
                return false;
            }

            if (!_mtProtoState.SaltHandler.IsSaltValid(connectionMessage.Salt) && deserialized is not BadServerSalt)
            {
                return false;
            }

            if (connectionMessage.AuthKeyId != 0)
            {
                _messagesHandler.MessagesTrackers.MessagesAckTracker.AcknowledgeNext(deserialized, connectionMessage.MessageId);
            }

            return true;
        }
        
    }
}