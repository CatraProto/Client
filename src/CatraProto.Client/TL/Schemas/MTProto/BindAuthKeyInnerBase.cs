using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class BindAuthKeyInnerBase : IObject
    {

[Newtonsoft.Json.JsonProperty("nonce")]
		public abstract long Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("temp_auth_key_id")]
		public abstract long TempAuthKeyId { get; set; }

[Newtonsoft.Json.JsonProperty("perm_auth_key_id")]
		public abstract long PermAuthKeyId { get; set; }

[Newtonsoft.Json.JsonProperty("temp_session_id")]
		public abstract long TempSessionId { get; set; }

[Newtonsoft.Json.JsonProperty("expires_at")]
		public abstract int ExpiresAt { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
