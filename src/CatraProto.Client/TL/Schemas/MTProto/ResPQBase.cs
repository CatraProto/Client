using System.Collections.Generic;
using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class ResPQBase : IObject
    {
        public abstract BigInteger Nonce { get; set; }
        public abstract BigInteger ServerNonce { get; set; }
        public abstract byte[] Pq { get; set; }
        public abstract IList<long> ServerPublicKeyFingerprints { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}