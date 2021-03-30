using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ServerDHParamsFail : IMethod<CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase>
	{


        public static int ConstructorId { get; } = 2043348061;

		public BigInteger Nonce { get; set; }
		public BigInteger ServerNonce { get; set; }
		public BigInteger NewNonceHash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(NewNonceHash);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			NewNonceHash = reader.Read<BigInteger>(128);

		}
	}
}