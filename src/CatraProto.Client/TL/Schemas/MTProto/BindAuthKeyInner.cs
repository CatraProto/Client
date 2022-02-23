using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class BindAuthKeyInner : CatraProto.Client.TL.Schemas.MTProto.BindAuthKeyInnerBase
    {
        public static int StaticConstructorId
        {
            get => 1973679973;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override long Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("temp_auth_key_id")]
        public sealed override long TempAuthKeyId { get; set; }

        [Newtonsoft.Json.JsonProperty("perm_auth_key_id")]
        public sealed override long PermAuthKeyId { get; set; }

        [Newtonsoft.Json.JsonProperty("temp_session_id")]
        public sealed override long TempSessionId { get; set; }

        [Newtonsoft.Json.JsonProperty("expires_at")]
        public sealed override int ExpiresAt { get; set; }


    #nullable enable
        public BindAuthKeyInner(long nonce, long tempAuthKeyId, long permAuthKeyId, long tempSessionId, int expiresAt)
        {
            Nonce = nonce;
            TempAuthKeyId = tempAuthKeyId;
            PermAuthKeyId = permAuthKeyId;
            TempSessionId = tempSessionId;
            ExpiresAt = expiresAt;
        }
    #nullable disable
        internal BindAuthKeyInner()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Nonce);
            writer.Write(TempAuthKeyId);
            writer.Write(PermAuthKeyId);
            writer.Write(TempSessionId);
            writer.Write(ExpiresAt);
        }

        public override void Deserialize(Reader reader)
        {
            Nonce = reader.Read<long>();
            TempAuthKeyId = reader.Read<long>();
            PermAuthKeyId = reader.Read<long>();
            TempSessionId = reader.Read<long>();
            ExpiresAt = reader.Read<int>();
        }

        public override string ToString()
        {
            return "bind_auth_key_inner";
        }
    }
}