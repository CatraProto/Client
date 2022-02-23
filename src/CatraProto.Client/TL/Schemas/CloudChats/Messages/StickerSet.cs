using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class StickerSet : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase
    {
        public static int StaticConstructorId
        {
            get => -1240849242;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("set")] public CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

        [Newtonsoft.Json.JsonProperty("packs")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

        [Newtonsoft.Json.JsonProperty("documents")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }


    #nullable enable
        public StickerSet(CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase set, IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> packs, IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> documents)
        {
            Set = set;
            Packs = packs;
            Documents = documents;
        }
    #nullable disable
        internal StickerSet()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Set);
            writer.Write(Packs);
            writer.Write(Documents);
        }

        public override void Deserialize(Reader reader)
        {
            Set = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
            Packs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>();
            Documents = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
        }

        public override string ToString()
        {
            return "messages.stickerSet";
        }
    }
}