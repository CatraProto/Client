namespace CatraProto.Client.Connections.Messages.Interfaces
{
    interface IMessage
    {
        public long AuthKeyId { get; set; }
        public long MessageId { get; set; }
        public byte[] Body { get; set; }

        public void Import(byte[] message);
        public byte[] Export();
    }
}