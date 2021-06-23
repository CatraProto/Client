using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Exceptions;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ServerDHParamsOk : ServerDHParamsBase
	{
		public static int ConstructorId { get; } = -790100132;
		public override BigInteger Nonce { get; set; }
		public override BigInteger ServerNonce { get; set; }
		public byte[] EncryptedAnswer { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
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
			writer.Write(EncryptedAnswer);
		}

		public override void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			EncryptedAnswer = reader.Read<byte[]>();
		}
	}
}