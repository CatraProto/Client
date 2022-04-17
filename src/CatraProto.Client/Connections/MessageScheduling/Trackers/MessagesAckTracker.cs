using System.Collections.Generic;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Auth;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling.Trackers
{
    internal class MessagesAckTracker
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