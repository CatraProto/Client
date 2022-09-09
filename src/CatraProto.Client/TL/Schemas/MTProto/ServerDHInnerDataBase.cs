using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class ServerDHInnerDataBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("nonce")]
        public abstract System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public abstract System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("g")] public abstract int G { get; set; }

        [Newtonsoft.Json.JsonProperty("dh_prime")]
        public abstract byte[] DhPrime { get; set; }

        [Newtonsoft.Json.JsonProperty("g_a")] public abstract byte[] GA { get; set; }

        [Newtonsoft.Json.JsonProperty("server_time")]
        public abstract int ServerTime { get; set; }

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