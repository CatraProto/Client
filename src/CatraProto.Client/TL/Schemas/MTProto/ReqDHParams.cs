using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ReqDHParams : IMethod<CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase>
	{


        public static int ConstructorId { get; } = -686627650;

		public BigInteger Nonce { get; set; }
		public BigInteger ServerNonce { get; set; }
		public byte[] P { get; set; }
		public byte[] Q { get; set; }
		public long PublicKeyFingerprint { get; set; }
		public byte[] EncryptedData { get; set; }

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
			writer.Write(P);
			writer.Write(Q);
			writer.Write(PublicKeyFingerprint);
			writer.Write(EncryptedData);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			P = reader.Read<byte[]>();
			Q = reader.Read<byte[]>();
			PublicKeyFingerprint = reader.Read<long>();
			EncryptedData = reader.Read<byte[]>();

		}
	}
}