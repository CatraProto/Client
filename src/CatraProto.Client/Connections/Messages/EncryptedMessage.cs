using CatraProto.Client.Connections.Messages.Interfaces;

namespace CatraProto.Client.Connections.Messages
{
    internal class EncryptedMessage : MessageBase
    {
        public override void Deserialize(byte[] message)
        {
            throw new System.NotImplementedException();
        }

        public override byte[] Serialize()
        {
            throw new System.NotImplementedException();
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}