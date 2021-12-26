namespace CatraProto.Client.Connections.MessageScheduling.Items
{
    class MessageProtocolInfo
    {
        public long? UpperMessageId { get; set; }
        public long? MessageId { get; set; }
        public int? SeqNo { get; set; }
    }
}