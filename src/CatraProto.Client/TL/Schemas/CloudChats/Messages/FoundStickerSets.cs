using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FoundStickerSets : CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase
    {
        public static int StaticConstructorId
        {
            get => -1963942446;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("sets")] public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }


    #nullable enable
        public FoundStickerSets(long hash, IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> sets)
        {
            Hash = hash;
            Sets = sets;
        }
    #nullable disable
        internal FoundStickerSets()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Hash);
            writer.Write(Sets);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<long>();
            Sets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();
        }

        public override string ToString()
        {
            return "messages.foundStickerSets";
        }
    }
}