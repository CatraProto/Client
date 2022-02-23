using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class RecentStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersBase
    {
        public static int StaticConstructorId
        {
            get => -1999405994;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("packs")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

        [Newtonsoft.Json.JsonProperty("stickers")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Stickers { get; set; }

        [Newtonsoft.Json.JsonProperty("dates")]
        public IList<int> Dates { get; set; }


    #nullable enable
        public RecentStickers(long hash, IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> packs, IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> stickers, IList<int> dates)
        {
            Hash = hash;
            Packs = packs;
            Stickers = stickers;
            Dates = dates;
        }
    #nullable disable
        internal RecentStickers()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Hash);
            writer.Write(Packs);
            writer.Write(Stickers);
            writer.Write(Dates);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<long>();
            Packs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>();
            Stickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            Dates = reader.ReadVector<int>();
        }

        public override string ToString()
        {
            return "messages.recentStickers";
        }
    }
}