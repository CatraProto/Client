using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StickerPackBase : IObject
    {

[JsonPropertyName("emoticon")]
		public abstract string Emoticon { get; set; }

[JsonPropertyName("documents")]
		public abstract IList<long> Documents { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
