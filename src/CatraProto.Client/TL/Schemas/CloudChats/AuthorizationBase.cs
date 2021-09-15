using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AuthorizationBase : IObject
    {

[Newtonsoft.Json.JsonProperty("current")]
		public abstract bool Current { get; set; }

[Newtonsoft.Json.JsonProperty("official_app")]
		public abstract bool OfficialApp { get; set; }

[Newtonsoft.Json.JsonProperty("password_pending")]
		public abstract bool PasswordPending { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public abstract long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("device_model")]
		public abstract string DeviceModel { get; set; }

[Newtonsoft.Json.JsonProperty("platform")]
		public abstract string Platform { get; set; }

[Newtonsoft.Json.JsonProperty("system_version")]
		public abstract string SystemVersion { get; set; }

[Newtonsoft.Json.JsonProperty("api_id")]
		public abstract int ApiId { get; set; }

[Newtonsoft.Json.JsonProperty("app_name")]
		public abstract string AppName { get; set; }

[Newtonsoft.Json.JsonProperty("app_version")]
		public abstract string AppVersion { get; set; }

[Newtonsoft.Json.JsonProperty("date_created")]
		public abstract int DateCreated { get; set; }

[Newtonsoft.Json.JsonProperty("date_active")]
		public abstract int DateActive { get; set; }

[Newtonsoft.Json.JsonProperty("ip")]
		public abstract string Ip { get; set; }

[Newtonsoft.Json.JsonProperty("country")]
		public abstract string Country { get; set; }

[Newtonsoft.Json.JsonProperty("region")]
		public abstract string Region { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
