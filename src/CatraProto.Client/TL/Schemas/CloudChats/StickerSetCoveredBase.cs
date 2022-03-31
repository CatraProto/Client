using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StickerSetCoveredBase : IObject
    {

[Newtonsoft.Json.JsonProperty("set")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
