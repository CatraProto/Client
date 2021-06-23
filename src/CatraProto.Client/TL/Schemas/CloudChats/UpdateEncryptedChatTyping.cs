using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateEncryptedChatTyping : UpdateBase
    {
        public static int ConstructorId { get; } = 386986326;
        public int ChatId { get; set; }

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
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
        }
    }
}