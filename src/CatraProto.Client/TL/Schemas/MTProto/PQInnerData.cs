using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Exceptions;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PQInnerData : PQInnerDataBase
	{
		public static int ConstructorId { get; } = -2083955988;
		public override byte[] Pq { get; set; }
		public override byte[] P { get; set; }
		public override byte[] Q { get; set; }
		public override BigInteger Nonce { get; set; }
		public override BigInteger ServerNonce { get; set; }
		public override BigInteger NewNonce { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pq);
			writer.Write(P);
			writer.Write(Q);
			var sizeNonce = Nonce.GetByteCount();
			if (sizeNonce != 16)
			{
				throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeNonce}bytes", SerializationException.SerializationErrors.BitSizeMismatch);
			}

			writer.Write(Nonce);
			var sizeServerNonce = ServerNonce.GetByteCount();
			if (sizeServerNonce != 16)
			{
				throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeServerNonce}bytes", SerializationException.SerializationErrors.BitSizeMismatch);
			}

			writer.Write(ServerNonce);
			var sizeNewNonce = NewNonce.GetByteCount();
			if (sizeNewNonce != 32)
			{
				throw new SerializationException($"ByteSize mismatch, should be 32bytes got {sizeNewNonce}bytes", SerializationException.SerializationErrors.BitSizeMismatch);
			}

			writer.Write(NewNonce);
		}

		public override void Deserialize(Reader reader)
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