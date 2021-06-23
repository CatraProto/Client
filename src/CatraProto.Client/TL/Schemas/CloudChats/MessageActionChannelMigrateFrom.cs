using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MessageActionChannelMigrateFrom : MessageActionBase
    {
        public static int ConstructorId { get; } = -1336546578;
        public string Title { get; set; }
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

            writer.Write(Title);
            writer.Write(ChatId);
        }

        public override void Deserialize(Reader reader)
        {
            Title = reader.Read<string>();
            ChatId = reader.Read<int>();
        }
    }
}