using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class EncryptedMessageService : EncryptedMessageBase
    {
        public static int ConstructorId { get; } = 594758406;
        public override long RandomId { get; set; }
        public override int ChatId { get; set; }
        public override int Date { get; set; }
        public override byte[] Bytes { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(RandomId);
            writer.Write(ChatId);
            writer.Write(Date);
            writer.Write(Bytes);
        }

        public override void Deserialize(Reader reader)
        {
            RandomId = reader.Read<long>();
            ChatId = reader.Read<int>();
            Date = reader.Read<int>();
            Bytes = reader.Read<byte[]>();
        }
    }
}