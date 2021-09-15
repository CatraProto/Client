namespace CatraProto.Client.Connections.MessageScheduling.Enums
{
    public enum MessageState
    {
        NotYetSent,
        MessageSent,
        Acknowledged,
        Replied,
        Canceled,
        Failed
    }
}