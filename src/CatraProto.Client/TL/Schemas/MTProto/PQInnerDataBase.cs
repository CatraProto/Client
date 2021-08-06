using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class PQInnerDataBase : IObject
    {

[JsonPropertyName("pq")]
		public abstract byte[] Pq { get; set; }

[JsonPropertyName("p")]
		public abstract byte[] P { get; set; }

[JsonPropertyName("q")]
		public abstract byte[] Q { get; set; }

[JsonPropertyName("nonce")]
		public abstract System.Numerics.BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public abstract System.Numerics.BigInteger ServerNonce { get; set; }

[JsonPropertyName("new_nonce")]
		public abstract System.Numerics.BigInteger NewNonce { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
