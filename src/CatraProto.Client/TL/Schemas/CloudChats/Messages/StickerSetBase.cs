using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class StickerSetBase : IObject
    {

[JsonPropertyName("set")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

[JsonPropertyName("packs")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

[JsonPropertyName("documents")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
