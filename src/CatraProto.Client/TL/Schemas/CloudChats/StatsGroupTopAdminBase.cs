using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsGroupTopAdminBase : IObject
    {

[JsonPropertyName("user_id")]
		public abstract int UserId { get; set; }

[JsonPropertyName("deleted")]
		public abstract int Deleted { get; set; }

[JsonPropertyName("kicked")]
		public abstract int Kicked { get; set; }

[JsonPropertyName("banned")]
		public abstract int Banned { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
