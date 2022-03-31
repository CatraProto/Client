using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputAppEventBase : IObject
    {

[Newtonsoft.Json.JsonProperty("time")]
		public abstract double Time { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public abstract string Type { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public abstract long Peer { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Data { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
