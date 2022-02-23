using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public abstract class ChannelDifferenceBase : IObject
    {

[Newtonsoft.Json.JsonProperty("final")]
		public abstract bool Final { get; set; }

[Newtonsoft.Json.JsonProperty("timeout")]
		public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
