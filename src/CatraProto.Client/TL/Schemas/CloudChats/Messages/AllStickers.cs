using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AllStickers : AllStickersBase
    {
        public static int StaticConstructorId
        {
            get => -302170017;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("hash")] public int Hash { get; set; }

        [JsonProperty("sets")] public IList<CloudChats.StickerSetBase> Sets { get; set; }


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
            Sets = reader.ReadVector<CloudChats.StickerSetBase>();
        }

        public override string ToString()
        {
            return "messages.allStickers";
        }
    }
}