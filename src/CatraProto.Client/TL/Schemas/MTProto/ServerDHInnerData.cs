using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ServerDHInnerData : IMethod<CatraProto.Client.TL.Schemas.MTProto.ServerDHInnerDataBase>
	{


        public static int ConstructorId { get; } = -1249309254;

		public BigInteger Nonce { get; set; }
		public BigInteger ServerNonce { get; set; }
		public int G { get; set; }
		public byte[] DhPrime { get; set; }
		public byte[] GA { get; set; }
		public int ServerTime { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			var sizeNonce = Nonce.GetByteCount();
			if(sizeNonce != 16){
				throw new CatraProto.TL.Exceptions.SerializationException($"ByteSize mismatch, should be 16bytes got {sizeNonce}bytes", CatraProto.TL.Exceptions.SerializationException.SerializationErrors.BitSizeMismatch);
			}
			writer.Write(Nonce);
			var sizeServerNonce = ServerNonce.GetByteCount();
			if(sizeServerNonce != 16){
				throw new CatraProto.TL.Exceptions.SerializationException($"ByteSize mismatch, should be 16bytes got {sizeServerNonce}bytes", CatraProto.TL.Exceptions.SerializationException.SerializationErrors.BitSizeMismatch);
			}
			writer.Write(ServerNonce);
			writer.Write(G);
			writer.Write(DhPrime);
			writer.Write(GA);
			writer.Write(ServerTime);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			G = reader.Read<int>();
			DhPrime = reader.Read<byte[]>();
			GA = reader.Read<byte[]>();
			ServerTime = reader.Read<int>();

		}
	}
}