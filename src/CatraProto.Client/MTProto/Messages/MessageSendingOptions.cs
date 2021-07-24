namespace CatraProto.Client.MTProto.Messages
{
    public class MessageSendingOptions
    {
        public AwaiterType AwaiterType { get; set; }
        public long SendWithMessageId { get; set; }
    }
}