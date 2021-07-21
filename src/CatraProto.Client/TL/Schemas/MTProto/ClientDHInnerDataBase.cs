using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class ClientDHInnerDataBase : IObject
    {

[JsonPropertyName("nonce")]
		public abstract System.Numerics.BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public abstract System.Numerics.BigInteger ServerNonce { get; set; }

[JsonPropertyName("retry_id")]
		public abstract long RetryId { get; set; }

[JsonPropertyName("g_b")]
		public abstract byte[] GB { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
