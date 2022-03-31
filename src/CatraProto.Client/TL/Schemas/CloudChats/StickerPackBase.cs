using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StickerPackBase : IObject
    {

[Newtonsoft.Json.JsonProperty("emoticon")]
		public abstract string Emoticon { get; set; }

[Newtonsoft.Json.JsonProperty("documents")]
		public abstract IList<long> Documents { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
