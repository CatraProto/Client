using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.Connections.MessageScheduling.Trackers;

namespace CatraProto.Client.Connections.MessageScheduling.Items
{ 
    class MessageStatus
    {
        public MessageCompletion MessageCompletion { get; }
        public MessageState MessageState { get; set; }
        public long? MessageId { get; set; }
        private MessagesHandler? _messagesHandler;
        
        public MessageStatus(MessageCompletion messageCompletion)
        {
            MessageCompletion = messageCompletion;
        }

        public void Reset()
        {
            if (MessageId is not null && _messagesHandler is not null)
            {
                _messagesHandler.MessagesTrackers.MessagesAckTracker.StopTracking(MessageId.Value);
                _messagesHandler.MessagesTrackers.MessageCompletionTracker.RemoveCompletion(MessageId.Value, out _);
            }
        }

        public void SetSent(long messageId)
        {
            MessageState = MessageState.MessageSent;
            MessageId = messageId;
            MessageCompletion.SetSent(messageId);
        }
        
        public void BindTo(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
            MessageCompletion.BindTo(messagesHandler);
        }
    }
}