using CatraProto.Client.Connections.MessageScheduling.Enums;

namespace CatraProto.Client.Connections.MessageScheduling.Items
{
    class MessageStatus
    {
        public MessageCompletion MessageCompletion { get; }
        public MessageState MessageState { get; set; }
        public MessageProtocolInfo MessageProtocolInfo { get; set; }

        public MessageStatus(MessageCompletion messageCompletion)
        {
            MessageProtocolInfo = new MessageProtocolInfo();
            MessageCompletion = messageCompletion;
        }
    }
}