using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Auth;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling.Trackers
{
    class MessagesAckTracker
    {
        private readonly AcknowledgementHandler _toServerAcksHandler;
        private readonly AcknowledgementHandler _fromClientAcksHandler;
        private readonly ILogger _logger;

        public MessagesAckTracker(ILogger logger)
        {
            _logger = logger.ForContext<MessagesAckTracker>();
            _toServerAcksHandler = new AcknowledgementHandler(logger);
            _fromClientAcksHandler = new AcknowledgementHandler(logger);
        }
        
        public void TrackMessage(MessageItem messageItem)
        {
            var messageBody = messageItem.Body;
            var messageId = messageItem.GetProtocolInfo().MessageId;
            if (!messageItem.MessageSendingOptions.IsEncrypted)
            {
                _logger.Verbose("Not keeping track of message {Message} because it's unencrypted", messageBody);
                return;
            }

            if (!AcknowledgementHandler.IsContentRelated(messageBody))
            {
                _logger.Verbose("Not keeping track of message {Message} because it's not content related", messageBody);
                return;
            }

            if (!messageId.HasValue)
            {
                throw new InvalidOperationException("Can't track a message without messageId");
            }

            _fromClientAcksHandler.SetAsNeedsAck(messageId.Value);
        }

        public List<MessageItem> GetAcknowledgements()
        {
            return _toServerAcksHandler.GetAckMessages();
        }

        public void AcknowledgeNext(long messageId)
        {
            _toServerAcksHandler.SetAsNeedsAck(messageId);
        }

        public void AcknowledgeNext(IObject body, long messageId)
        {
            if (AcknowledgementHandler.IsContentRelated(body))
            {
                _toServerAcksHandler.SetAsNeedsAck(messageId);
            }
            else
            {
                _logger.Verbose("Not acknowledging message [{MId}]({MObj}) because it's not content related", body, messageId);
            }
        }
    }
}