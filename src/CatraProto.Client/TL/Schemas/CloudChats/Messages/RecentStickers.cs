using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class RecentStickers : RecentStickersBase
    {
        public static int StaticConstructorId
        {
            get => 586395571;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("hash")] public int Hash { get; set; }

        [JsonProperty("packs")] public IList<StickerPackBase> Packs { get; set; }

        [JsonProperty("stickers")] public IList<DocumentBase> Stickers { get; set; }

        [JsonProperty("dates")] public IList<int> Dates { get; set; }


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

        public override string ToString()
        {
            return "messages.recentStickers";
        }
    }
}