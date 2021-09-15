using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WebAuthorizationBase : IObject
    {

[Newtonsoft.Json.JsonProperty("hash")]
		public abstract long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("bot_id")]
		public abstract int BotId { get; set; }

[Newtonsoft.Json.JsonProperty("domain")]
		public abstract string Domain { get; set; }

[Newtonsoft.Json.JsonProperty("browser")]
		public abstract string Browser { get; set; }

[Newtonsoft.Json.JsonProperty("platform")]
		public abstract string Platform { get; set; }

[Newtonsoft.Json.JsonProperty("date_created")]
		public abstract int DateCreated { get; set; }

[Newtonsoft.Json.JsonProperty("date_active")]
		public abstract int DateActive { get; set; }

[Newtonsoft.Json.JsonProperty("ip")]
		public abstract string Ip { get; set; }

[Newtonsoft.Json.JsonProperty("region")]
		public abstract string Region { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
