using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ClientDHInnerData : IMethod<CatraProto.Client.TL.Schemas.MTProto.ClientDHInnerDataBase>
	{


        public static int ConstructorId { get; } = 1715713620;

		public BigInteger Nonce { get; set; }
		public BigInteger ServerNonce { get; set; }
		public long RetryId { get; set; }
		public byte[] GB { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(RetryId);
			writer.Write(GB);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			RetryId = reader.Read<long>();
			GB = reader.Read<byte[]>();

		}
	}
}