using System.IO;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Extensions;

namespace CatraProto.Client.Connections.Messages
{
    internal class UnencryptedMessage : MessageBase
    {
        public override void Deserialize(byte[] message)
        {
            CheckDisposed();
            using var stream = message.ToMemoryStream();
            using var reader = new BinaryReader(stream);
            AuthKeyId = reader.ReadInt64();
            MessageId = reader.ReadInt64();
            var length = reader.ReadInt32();
            var buffer = new byte[length];
            reader.Read(buffer);
            Message = buffer.ToMemoryStream();
        }

        public override byte[] Serialize()
        {
            CheckDisposed();
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream);
            writer.Write(AuthKeyId);
            writer.Write(MessageId);
            writer.Write(Length);
            writer.Write(Message.ToArray());
            return stream.ToArray();
        }
    }
}
