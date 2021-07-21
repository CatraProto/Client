using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsPercentValueBase : IObject
    {

[JsonPropertyName("part")]
		public abstract double Part { get; set; }

[JsonPropertyName("total")]
		public abstract double Total { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
