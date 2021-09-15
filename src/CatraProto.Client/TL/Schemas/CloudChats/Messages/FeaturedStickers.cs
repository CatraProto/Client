using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FeaturedStickers : FeaturedStickersBase
    {
        public static int StaticConstructorId
        {
            get => -1230257343;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("hash")] public int Hash { get; set; }

        [JsonProperty("count")] public override int Count { get; set; }

        [JsonProperty("sets")] public IList<StickerSetCoveredBase> Sets { get; set; }

        [JsonProperty("unread")] public IList<long> Unread { get; set; }


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

        public override string ToString()
        {
            return "messages.featuredStickers";
        }
    }
}