using CatraProto.Client.Connections.MessageScheduling.Enums;

namespace CatraProto.Client.Connections.MessageScheduling.Items
{ 
    class MessageStatus
    {
        public MessageCompletion MessageCompletion { get; }
        public MessageState MessageState { get; set; } = MessageState.NotYetSent;
        public long? MessageId { get; set; }

        public MessageStatus(MessageCompletion messageCompletion)
        {
            MessageCompletion = messageCompletion;
        }

    }
}