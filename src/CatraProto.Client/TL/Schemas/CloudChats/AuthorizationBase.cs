using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AuthorizationBase : IObject
    {

[JsonPropertyName("current")]
		public abstract bool Current { get; set; }

[JsonPropertyName("official_app")]
		public abstract bool OfficialApp { get; set; }

[JsonPropertyName("password_pending")]
		public abstract bool PasswordPending { get; set; }

[JsonPropertyName("hash")]
		public abstract long Hash { get; set; }

[JsonPropertyName("device_model")]
		public abstract string DeviceModel { get; set; }

[JsonPropertyName("platform")]
		public abstract string Platform { get; set; }

[JsonPropertyName("system_version")]
		public abstract string SystemVersion { get; set; }

[JsonPropertyName("api_id")]
		public abstract int ApiId { get; set; }

[JsonPropertyName("app_name")]
		public abstract string AppName { get; set; }

[JsonPropertyName("app_version")]
		public abstract string AppVersion { get; set; }

[JsonPropertyName("date_created")]
		public abstract int DateCreated { get; set; }

[JsonPropertyName("date_active")]
		public abstract int DateActive { get; set; }

[JsonPropertyName("ip")]
		public abstract string Ip { get; set; }

[JsonPropertyName("country")]
		public abstract string Country { get; set; }

[JsonPropertyName("region")]
		public abstract string Region { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
