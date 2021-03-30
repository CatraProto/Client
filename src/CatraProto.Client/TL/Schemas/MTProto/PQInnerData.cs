using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PQInnerData : IMethod<CatraProto.Client.TL.Schemas.MTProto.PQInnerDataBase>
	{


        public static int ConstructorId { get; } = -2083955988;

		public byte[] Pq { get; set; }
		public byte[] P { get; set; }
		public byte[] Q { get; set; }
		public BigInteger Nonce { get; set; }
		public BigInteger ServerNonce { get; set; }
		public BigInteger NewNonce { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pq);
			writer.Write(P);
			writer.Write(Q);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(NewNonce);

		}

		public void Deserialize(Reader reader)
		{
			Pq = reader.Read<byte[]>();
			P = reader.Read<byte[]>();
			Q = reader.Read<byte[]>();
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			NewNonce = reader.Read<BigInteger>(256);

		}
	}
}