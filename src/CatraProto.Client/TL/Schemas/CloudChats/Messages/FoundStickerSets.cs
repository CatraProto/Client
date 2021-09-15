using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FoundStickerSets : FoundStickerSetsBase
    {
        public static int StaticConstructorId
        {
            get => 1359533640;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("hash")] public int Hash { get; set; }

        [JsonProperty("sets")] public IList<StickerSetCoveredBase> Sets { get; set; }


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
            writer.Write(Sets);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            Sets = reader.ReadVector<StickerSetCoveredBase>();
        }

        public override string ToString()
        {
            return "messages.foundStickerSets";
        }
    }
}