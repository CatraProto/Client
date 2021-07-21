using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChannelAdminLogEventBase : IObject
    {

[JsonPropertyName("id")]
		public abstract long Id { get; set; }

[JsonPropertyName("date")]
		public abstract int Date { get; set; }

[JsonPropertyName("user_id")]
		public abstract int UserId { get; set; }

[JsonPropertyName("action")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase Action { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
