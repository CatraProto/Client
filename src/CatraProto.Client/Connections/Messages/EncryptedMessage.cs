using System.Threading;
using CatraProto.Client.Connections.Messages.Interfaces;

namespace CatraProto.Client.Connections.Messages
{
    internal sealed class EncryptedMessage : MessageBase
    {
        public CancellationToken Token { get; set; } = default;

        public EncryptedMessage()
        {
        }

        public EncryptedMessage(byte[] message)
        {
            Deserialize(message);
        }

        public override void Deserialize(byte[] message)
        {
            throw new System.NotImplementedException();
        }

        public override byte[] Serialize()
        {
            throw new System.NotImplementedException();
        }
    }
}