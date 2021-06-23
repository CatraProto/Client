using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class RecentMeUrlChat : RecentMeUrlBase
    {
        public static int ConstructorId { get; } = -1608834311;
        public override string Url { get; set; }
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

            writer.Write(Url);
            writer.Write(ChatId);
        }

        public override void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
            ChatId = reader.Read<int>();
        }
    }
}