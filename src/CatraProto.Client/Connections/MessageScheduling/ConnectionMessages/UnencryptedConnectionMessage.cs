using System.IO;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.Extensions;

namespace CatraProto.Client.Connections.MessageScheduling.ConnectionMessages
{
    sealed class UnencryptedConnectionMessage : IConnectionMessage
    {
        public long AuthKeyId { get => 0; }
        public long MessageId { get; private set; }
        public byte[] Body { get; private set; }

        public UnencryptedConnectionMessage(long messageId, byte[] body)
        {
            MessageId = messageId;
            Body = body;
        }
        
        public UnencryptedConnectionMessage(byte[] payload)
        {
            Body = null!;
            if (payload.Length == 4)
            {
                Body = payload;
            }
            else
            {
                Import(payload);
            }
        }

        public void Import(byte[] message)
        {
            using (var reader = new BinaryReader(message.ToMemoryStream()))
            {
                reader.BaseStream.Seek(8, SeekOrigin.Current);
                MessageId = reader.ReadInt64();
                var length = reader.ReadInt32();
                Body = reader.ReadBytes(length);
            }
        }

        public byte[] Export()
        {
            using (var writer = new BinaryWriter(new MemoryStream()))
            {
                writer.Write(AuthKeyId);
                writer.Write(MessageId);
                writer.Write(Body.Length);
                writer.Write(Body);
                return ((MemoryStream)writer.BaseStream).ToArray();
            }
        }
    }
}