using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class SentEncryptedMessage : SentEncryptedMessageBase
    {
        public static int ConstructorId { get; } = 1443858741;
        public override int Date { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            Date = reader.Read<int>();
        }
    }
}