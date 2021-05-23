using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Numerics;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ResPQ : IMethod
	{


        public static int ConstructorId { get; } = 85337187;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.ResPQ);
		public bool IsVector { get; init; } = false;
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