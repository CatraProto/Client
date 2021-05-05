using System.Threading;
using CatraProto.Client.Connections.Messages.Interfaces;

namespace CatraProto.Client.Connections.Messages
{
    //Unencrypted Message
    // | int64 auth_key_id = 0 | int64 message_id | int32 message_data_length | bytes message_data |
    internal sealed class UnencryptedMessage : IMessage
    {
        public long AuthKeyId { get; set; }
        public long MessageId { get; set; }
        public byte[] Body { get; set; }
        public CancellationToken Token { get; set; }

        public UnencryptedMessage()
        {
        }

        public UnencryptedMessage(byte[] message)
        {
            Import(message);
        }

        public void Import(byte[] message)
        {
            throw new System.NotImplementedException();
        }

        public byte[] Export()
        {
            throw new System.NotImplementedException();
        }
    }
}