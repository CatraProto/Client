using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public abstract class ClientDHInnerDataBase : IObject
	{
		public abstract BigInteger Nonce { get; set; }
		public abstract BigInteger ServerNonce { get; set; }
		public abstract long RetryId { get; set; }
		public abstract byte[] GB { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}