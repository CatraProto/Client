using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateEncryptedMessagesRead : UpdateBase
    {
        public static int ConstructorId { get; } = 956179895;
        public int ChatId { get; set; }
        public int MaxDate { get; set; }
        public int Date { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(ChatId);
            writer.Write(MaxDate);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            MaxDate = reader.Read<int>();
            Date = reader.Read<int>();
        }
    }
}