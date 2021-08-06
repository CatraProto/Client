using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Auth;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling.Trackers
{
    class MessagesAckTracker : PeriodicLoop
    {
        private readonly ConcurrentDictionary<long, MessageItem> _messages = new ConcurrentDictionary<long, MessageItem>();
        private readonly AcknowledgementHandler _serverAcksHandler = new AcknowledgementHandler();
        private readonly AcknowledgementHandler _clientAcksHandler = new AcknowledgementHandler();
        private readonly MessagesQueue _messagesQueue;
        private readonly ILogger _logger;

        public MessagesAckTracker(MessagesQueue messagesQueue, ILogger logger) : base(TimeSpan.FromMinutes(4))
        {
            _logger = logger.ForContext<MessagesAckTracker>();
            _messagesQueue = messagesQueue;
        }

        public void AcknowledgeAndReschedule(List<long> ids)
        {
            foreach (var id in ids)
            {
                _clientAcksHandler.SetAsReceived(id);
            }
        }

        public void TrackMessage(MessageItem messageItem)
        {
            var messageBody = messageItem.Body;
            if (!messageItem.MessageSendingOptions.IsEncrypted)
            {
                _logger.Information("Not keeping track of message {Message} because it's unencrypted", messageBody);
                return;
            }
            
            if (!AcknowledgementHandler.IsContentRelated(messageBody))
            {
                _logger.Information("Not keeping track of message {Message} because it's not content related", messageBody);
                return;
            }

            if (!messageItem.MessageStatus.MessageId.HasValue)
            {
                throw new InvalidOperationException("Can't track a message without messageId");
            }
            
            _clientAcksHandler.SetAsNeedsAck(messageItem.MessageStatus.MessageId.Value);
        }

        public IEnumerable<MessageItem> GetAcknowledgements()
        {
            return _serverAcksHandler.GetAckMessages();
        }
        
        public void AcknowledgeNext(IObject body, long messageId)
        {
            if (AcknowledgementHandler.IsContentRelated(body))
            {
                _serverAcksHandler.SetAsNeedsAck(messageId);
            }
        }
    }
}