using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class FeaturedStickers : FeaturedStickersBase
    {
        public static int ConstructorId { get; } = -1230257343;
        public int Hash { get; set; }
        public override int Count { get; set; }
        public IList<StickerSetCoveredBase> Sets { get; set; }
        public IList<long> Unread { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Hash);
            writer.Write(Count);
            writer.Write(Sets);
            writer.Write(Unread);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            Count = reader.Read<int>();
            Sets = reader.ReadVector<StickerSetCoveredBase>();
            Unread = reader.ReadVector<long>();
        }
    }
}