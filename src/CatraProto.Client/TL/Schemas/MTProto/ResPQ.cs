using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ResPQ : IMethod<CatraProto.Client.TL.Schemas.MTProto.ResPQBase>
	{


        public static int ConstructorId { get; } = 85337187;

		public BigInteger Nonce { get; set; }
		public BigInteger ServerNonce { get; set; }
		public byte[] Pq { get; set; }
		public IList<long> ServerPublicKeyFingerprints { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(Pq);
			writer.Write(ServerPublicKeyFingerprints);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			Pq = reader.Read<byte[]>();
			ServerPublicKeyFingerprints = reader.ReadVector<long>();

		}
	}
}