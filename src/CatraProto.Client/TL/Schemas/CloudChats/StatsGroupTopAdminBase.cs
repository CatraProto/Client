using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsGroupTopAdminBase : IObject
    {

[Newtonsoft.Json.JsonProperty("user_id")]
		public abstract int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("deleted")]
		public abstract int Deleted { get; set; }

[Newtonsoft.Json.JsonProperty("kicked")]
		public abstract int Kicked { get; set; }

[Newtonsoft.Json.JsonProperty("banned")]
		public abstract int Banned { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
