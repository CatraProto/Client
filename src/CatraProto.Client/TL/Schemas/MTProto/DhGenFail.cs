using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DhGenFail : IMethod<CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase>
	{


        public static int ConstructorId { get; } = -1499615742;

		public BigInteger Nonce { get; set; }
		public BigInteger ServerNonce { get; set; }
		public BigInteger NewNonceHash3 { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(NewNonceHash3);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			NewNonceHash3 = reader.Read<BigInteger>(128);

		}
	}
}