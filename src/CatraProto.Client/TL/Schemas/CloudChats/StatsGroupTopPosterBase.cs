using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsGroupTopPosterBase : IObject
    {

[Newtonsoft.Json.JsonProperty("user_id")]
		public abstract int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public abstract int Messages { get; set; }

[Newtonsoft.Json.JsonProperty("avg_chars")]
		public abstract int AvgChars { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
