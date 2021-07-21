using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsGroupTopInviterBase : IObject
    {

[JsonPropertyName("user_id")]
		public abstract int UserId { get; set; }

[JsonPropertyName("invitations")]
		public abstract int Invitations { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
