using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChannelAdminLogEventBase : IObject
    {

[Newtonsoft.Json.JsonProperty("id")]
		public abstract long Id { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public abstract int Date { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public abstract int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("action")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase Action { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
