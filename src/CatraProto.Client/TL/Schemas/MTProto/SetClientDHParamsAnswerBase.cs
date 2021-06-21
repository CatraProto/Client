using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;


namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class SetClientDHParamsAnswerBase : IObject
    {
		public abstract BigInteger Nonce { get; set; }
		public abstract BigInteger ServerNonce { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
