using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class BindAuthKeyInnerBase : IObject
    {

[JsonPropertyName("nonce")]
		public abstract long Nonce { get; set; }

[JsonPropertyName("temp_auth_key_id")]
		public abstract long TempAuthKeyId { get; set; }

[JsonPropertyName("perm_auth_key_id")]
		public abstract long PermAuthKeyId { get; set; }

[JsonPropertyName("temp_session_id")]
		public abstract long TempSessionId { get; set; }

[JsonPropertyName("expires_at")]
		public abstract int ExpiresAt { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
