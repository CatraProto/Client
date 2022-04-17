namespace CatraProto.Client.Connections.MessageScheduling.Enums
{
    public enum MessageState
    {
        NotYetSent,
        MessageSent,
        Acknowledged,
        Completed,
        Canceled,
        Failed
    }
}