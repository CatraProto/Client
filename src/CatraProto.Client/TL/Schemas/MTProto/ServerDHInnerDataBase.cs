using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class ServerDHInnerDataBase : IObject
    {

[JsonPropertyName("nonce")]
		public abstract System.Numerics.BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public abstract System.Numerics.BigInteger ServerNonce { get; set; }

[JsonPropertyName("g")]
		public abstract int G { get; set; }

[JsonPropertyName("dh_prime")]
		public abstract byte[] DhPrime { get; set; }

[JsonPropertyName("g_a")]
		public abstract byte[] GA { get; set; }

[JsonPropertyName("server_time")]
		public abstract int ServerTime { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
