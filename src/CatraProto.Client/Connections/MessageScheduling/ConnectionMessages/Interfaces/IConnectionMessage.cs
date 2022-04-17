namespace CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces
{
    internal interface IConnectionMessage
    {
        public long AuthKeyId { get; }
        public long MessageId { get; }
        public byte[] Body { get; }

        public void Import(byte[] message);
        public byte[] Export();
    }
}