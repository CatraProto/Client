using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class FutureSaltBase : IObject
    {

[JsonPropertyName("valid_since")]
		public abstract int ValidSince { get; set; }

[JsonPropertyName("valid_until")]
		public abstract int ValidUntil { get; set; }

[JsonPropertyName("salt")]
		public abstract long Salt { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
