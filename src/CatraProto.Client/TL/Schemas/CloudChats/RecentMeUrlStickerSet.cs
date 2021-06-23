using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class RecentMeUrlStickerSet : RecentMeUrlBase
    {
        public static int ConstructorId { get; } = -1140172836;
        public override string Url { get; set; }
        public StickerSetCoveredBase Set { get; set; }

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
            writer.Write(Set);
        }

        public override void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
            Set = reader.Read<StickerSetCoveredBase>();
        }
    }
}