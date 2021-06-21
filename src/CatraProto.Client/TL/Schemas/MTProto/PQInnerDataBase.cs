using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;


namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class PQInnerDataBase : IObject
    {
		public abstract byte[] Pq { get; set; }
		public abstract byte[] P { get; set; }
		public abstract byte[] Q { get; set; }
		public abstract BigInteger Nonce { get; set; }
		public abstract BigInteger ServerNonce { get; set; }
		public abstract BigInteger NewNonce { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
