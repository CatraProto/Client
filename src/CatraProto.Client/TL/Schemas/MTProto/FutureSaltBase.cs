using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class FutureSaltBase : IObject
    {

[Newtonsoft.Json.JsonProperty("valid_since")]
		public abstract int ValidSince { get; set; }

[Newtonsoft.Json.JsonProperty("valid_until")]
		public abstract int ValidUntil { get; set; }

[Newtonsoft.Json.JsonProperty("salt")]
		public abstract long Salt { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
