using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputAppEventBase : IObject
    {

[JsonPropertyName("time")]
		public abstract double Time { get; set; }

[JsonPropertyName("type")]
		public abstract string Type { get; set; }

[JsonPropertyName("peer")]
		public abstract long Peer { get; set; }

[JsonPropertyName("data")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Data { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
