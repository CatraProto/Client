using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Auth;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling.Trackers
{
    class MessagesAckTracker : PeriodicLoop
    {
        private readonly ConcurrentDictionary<long, MessageItem> _messages = new ConcurrentDictionary<long, MessageItem>();
        private readonly AcknowledgementHandler _serverAcksHandler;
        private readonly AcknowledgementHandler _clientAcksHandler;
        private readonly MessagesQueue _messagesQueue;
        private readonly ILogger _logger;

        public MessagesAckTracker(MessagesQueue messagesQueue, ILogger logger) : base(TimeSpan.FromMinutes(4))
        {
            _logger = logger.ForContext<MessagesAckTracker>();
            _serverAcksHandler = new AcknowledgementHandler(logger);
            _clientAcksHandler = new AcknowledgementHandler(logger);
            _messagesQueue = messagesQueue;
            Task.Run(Loop);
        }

        public async Task Loop()
        {
            while (true)
            {
                SetLoopStopped();
                return;
                await StateSignaler.WaitStateAsync(false, default, ResumableSignalState.Resume, ResumableSignalState.Start);
                _logger.Information("aaaaa");
            }
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
            var messageId = messageItem.GetMessageId();
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

            _clientAcksHandler.SetAsNeedsAck(messageId.Value);
        }

        public void StopTracking(long messageId)
        {
            _messages.TryRemove(messageId, out _);
        }

        public void ServerSentAcks(MsgsAck msgsAck)
        {
            foreach (var msgsAckMsgId in msgsAck.MsgIds)
            {
                if (_messages.TryRemove(msgsAckMsgId, out var item))
                {
                    _logger.Information("Received acknowledgment for message {Id} by the server", msgsAckMsgId);
                    item.SetAcknowledged();
                }
            }
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
            else
            {
                _logger.Verbose("Not acknowledging message [{MId}]({MObj}) because it's not content related", body, messageId);
            }
        }
    }
}