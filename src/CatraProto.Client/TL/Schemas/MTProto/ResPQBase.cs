using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class ResPQBase : IObject
    {

[Newtonsoft.Json.JsonProperty("nonce")]
		public abstract System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public abstract System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("pq")]
		public abstract byte[] Pq { get; set; }

[Newtonsoft.Json.JsonProperty("server_public_key_fingerprints")]
		public abstract IList<long> ServerPublicKeyFingerprints { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
