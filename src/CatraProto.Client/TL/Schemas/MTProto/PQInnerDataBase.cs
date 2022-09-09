using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class PQInnerDataBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("pq")] public abstract byte[] Pq { get; set; }

        [Newtonsoft.Json.JsonProperty("p")] public abstract byte[] P { get; set; }

        [Newtonsoft.Json.JsonProperty("q")] public abstract byte[] Q { get; set; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public abstract System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public abstract System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("new_nonce")]
        public abstract System.Numerics.BigInteger NewNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("dc")] public abstract int Dc { get; set; }

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