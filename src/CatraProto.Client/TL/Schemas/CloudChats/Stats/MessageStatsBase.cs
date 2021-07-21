using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class MessageStatsBase : IObject
    {

[JsonPropertyName("views_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ViewsGraph { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
