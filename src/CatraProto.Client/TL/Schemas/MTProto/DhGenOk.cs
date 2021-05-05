using System;
using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DhGenOk : IMethod<SetClientDHParamsAnswerBase>
	{


        public static int ConstructorId { get; } = 1003222836;

		public Type Type { get; init; } = typeof(DhGenOk);
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
				throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeNonce}bytes", SerializationException.SerializationErrors.BitSizeMismatch);
			}
			writer.Write(Nonce);
			var sizeServerNonce = ServerNonce.GetByteCount();
			if(sizeServerNonce != 16){
				throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeServerNonce}bytes", SerializationException.SerializationErrors.BitSizeMismatch);
			}
			writer.Write(ServerNonce);
			var sizeNewNonceHash1 = NewNonceHash1.GetByteCount();
			if(sizeNewNonceHash1 != 16){
				throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeNewNonceHash1}bytes", SerializationException.SerializationErrors.BitSizeMismatch);
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