using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FavedStickers : FavedStickersBase
    {
        public static int StaticConstructorId
        {
            get => -209768682;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("hash")] public int Hash { get; set; }

        [JsonProperty("packs")] public IList<StickerPackBase> Packs { get; set; }

        [JsonProperty("stickers")] public IList<DocumentBase> Stickers { get; set; }


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
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            Packs = reader.ReadVector<StickerPackBase>();
            Stickers = reader.ReadVector<DocumentBase>();
        }

        public override string ToString()
        {
            return "messages.favedStickers";
        }
    }
}