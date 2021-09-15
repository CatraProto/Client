using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsPercentValueBase : IObject
    {

[Newtonsoft.Json.JsonProperty("part")]
		public abstract double Part { get; set; }

[Newtonsoft.Json.JsonProperty("total")]
		public abstract double Total { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
