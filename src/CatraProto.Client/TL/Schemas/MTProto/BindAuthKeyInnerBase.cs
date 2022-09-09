using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}