using System;
using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ReqPq : IMethod
	{
		public static int ConstructorId { get; } = 1615239032;
		public BigInteger Nonce { get; set; }

		public Type Type { get; init; } = typeof(ResPQBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			var sizeNonce = Nonce.GetByteCount();
			if (sizeNonce != 16)
			{
				throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeNonce}bytes",
					SerializationException.SerializationErrors.BitSizeMismatch);
			}

			writer.Write(Nonce);
		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
		}
	}
}