using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WebAuthorizationBase : IObject
    {

[JsonPropertyName("hash")]
		public abstract long Hash { get; set; }

[JsonPropertyName("bot_id")]
		public abstract int BotId { get; set; }

[JsonPropertyName("domain")]
		public abstract string Domain { get; set; }

[JsonPropertyName("browser")]
		public abstract string Browser { get; set; }

[JsonPropertyName("platform")]
		public abstract string Platform { get; set; }

[JsonPropertyName("date_created")]
		public abstract int DateCreated { get; set; }

[JsonPropertyName("date_active")]
		public abstract int DateActive { get; set; }

[JsonPropertyName("ip")]
		public abstract string Ip { get; set; }

[JsonPropertyName("region")]
		public abstract string Region { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
