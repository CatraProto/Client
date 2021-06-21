using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class ServerDHInnerDataBase : IObject
    {
        public abstract BigInteger Nonce { get; set; }
        public abstract BigInteger ServerNonce { get; set; }
        public abstract int G { get; set; }
        public abstract byte[] DhPrime { get; set; }
        public abstract byte[] GA { get; set; }
        public abstract int ServerTime { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}