using System.IO;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.Extensions;

namespace CatraProto.Client.Connections.Messages
{
    //Unencrypted Message
    // | int64 auth_key_id = 0 | int64 message_id | int32 message_data_length | bytes message_data |
    internal sealed class UnencryptedMessage : MessageBase
    {
        public UnencryptedMessage()
        {
        }

        public UnencryptedMessage(byte[] message)
        {
            Deserialize(message);
        }

        public override void Deserialize(byte[] message)
        {
            var stream = message.ToMemoryStream();
            using var reader = new BinaryReader(stream);
            AuthKeyId = reader.ReadInt64();
            MessageId = reader.ReadInt64();
            var length = reader.ReadInt32();
            var buffer = new byte[length];
            reader.Read(buffer);
            Message = buffer;
        }

        public override byte[] Serialize()
        {
            var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream);
            writer.Write(AuthKeyId);
            writer.Write(MessageId);
            writer.Write(Length);
            writer.Write(Message);
            return stream.ToArray();
        }
    }
}