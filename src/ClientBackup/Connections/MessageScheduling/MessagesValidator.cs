using System;
using System.Linq;
using System.Threading.Tasks;
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

            switch (deserialized)
            {
                case BadServerSalt badServerSalt:
                    HandleBadServerSalt(badServerSalt);
                    break;
                case NewSessionCreated newSessionCreated:
                    HandleNewSessionCreation(newSessionCreated, connectionMessage.SessionId);
                    break;
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

            if (!_mtProtoState.SaltHandler.IsSaltValid(connectionMessage.Salt))
            {
                return false;
            }

            if (connectionMessage.AuthKeyId != 0)
            {
                _messagesHandler.MessagesTrackers.AcknowledgementHandler.SendAcknowledgment(connectionMessage.MessageId, deserialized);
            }

            return true;
        }

        private void HandleNewSessionCreation(NewSessionCreated newSessionCreated, long sessionId)
        {
            _mtProtoState.SessionIdHandler.SetSessionId(sessionId);
            _mtProtoState.SaltHandler.SetSalt(newSessionCreated.ServerSalt);
            _mtProtoState.SeqnoHandler.ContentRelatedReceived = 0;
            _logger.Information("New session created, new server salt {Salt}, new SessionId {SessionId}", newSessionCreated.ServerSalt, sessionId);
            
            if (_mtProtoState.ConnectionInfo.Main)
            {
                //Not awaiting is fine here. 
                _mtProtoState.Client.UpdatesReceiver.ForceGetDifferenceAllAsync(false);
            }
        }

        private void HandleBadServerSalt(BadServerSalt serverSalt)
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
    }
}