using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class RecentStickers : RecentStickersBase
    {
        public static int ConstructorId { get; } = 586395571;
        public int Hash { get; set; }
        public IList<StickerPackBase> Packs { get; set; }
        public IList<DocumentBase> Stickers { get; set; }
        public IList<int> Dates { get; set; }

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
            writer.Write(Packs);
            writer.Write(Stickers);
            writer.Write(Dates);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            Packs = reader.ReadVector<StickerPackBase>();
            Stickers = reader.ReadVector<DocumentBase>();
            Dates = reader.ReadVector<int>();
        }
    }
}