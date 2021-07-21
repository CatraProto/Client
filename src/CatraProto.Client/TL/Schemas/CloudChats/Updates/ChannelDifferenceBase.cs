using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public abstract class ChannelDifferenceBase : IObject
    {

[JsonPropertyName("final")]
		public abstract bool Final { get; set; }

[JsonPropertyName("timeout")]
		public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
