using System;
using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class SetClientDHParams : IMethod
	{
		public static int ConstructorId { get; } = -184262881;
		public BigInteger Nonce { get; set; }
		public BigInteger ServerNonce { get; set; }
		public byte[] EncryptedData { get; set; }

		public Type Type { get; init; } = typeof(SetClientDHParamsAnswerBase);
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
			var sizeServerNonce = ServerNonce.GetByteCount();
			if (sizeServerNonce != 16)
			{
				throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeServerNonce}bytes",
					SerializationException.SerializationErrors.BitSizeMismatch);
			}

			writer.Write(ServerNonce);
			writer.Write(EncryptedData);
		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			EncryptedData = reader.Read<byte[]>();
		}
	}
}