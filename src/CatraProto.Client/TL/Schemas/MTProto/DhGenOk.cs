using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DhGenOk : IMethod
	{


        public static int ConstructorId { get; } = 1003222836;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.DhGenOk);
		public bool IsVector { get; init; } = false;
		public BigInteger Nonce { get; set; }
		public BigInteger ServerNonce { get; set; }
		public BigInteger NewNonceHash1 { get; set; }

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
			var sizeNewNonceHash1 = NewNonceHash1.GetByteCount();
			if(sizeNewNonceHash1 != 16){
				throw new CatraProto.TL.Exceptions.SerializationException($"ByteSize mismatch, should be 16bytes got {sizeNewNonceHash1}bytes", CatraProto.TL.Exceptions.SerializationException.SerializationErrors.BitSizeMismatch);
			}
			writer.Write(NewNonceHash1);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			NewNonceHash1 = reader.Read<BigInteger>(128);

		}
	}
}