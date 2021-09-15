using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class StickerSetBase : IObject
    {

[Newtonsoft.Json.JsonProperty("set")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

[Newtonsoft.Json.JsonProperty("packs")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

[Newtonsoft.Json.JsonProperty("documents")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
