using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class NearestDcBase : IObject
    {

[Newtonsoft.Json.JsonProperty("country")]
		public abstract string Country { get; set; }

[Newtonsoft.Json.JsonProperty("this_dc")]
		public abstract int ThisDc { get; set; }

[Newtonsoft.Json.JsonProperty("nearest_dc")]
		public abstract int NearestDcField { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
