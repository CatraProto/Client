using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class NearestDcBase : IObject
    {

[JsonPropertyName("country")]
		public abstract string Country { get; set; }

[JsonPropertyName("this_dc")]
		public abstract int ThisDc { get; set; }

[JsonPropertyName("NearestDc_")]
		public abstract int NearestDc_ { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
