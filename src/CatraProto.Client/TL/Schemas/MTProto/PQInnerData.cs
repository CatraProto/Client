using System.Numerics;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Exceptions;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PQInnerData : PQInnerDataBase
	{


        public static int StaticConstructorId { get => -2083955988; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("pq")]
		public override byte[] Pq { get; set; }

[JsonPropertyName("p")]
		public override byte[] P { get; set; }

[JsonPropertyName("q")]
		public override byte[] Q { get; set; }

[JsonPropertyName("nonce")]
		public override BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public override BigInteger ServerNonce { get; set; }

[JsonPropertyName("new_nonce")]
		public override BigInteger NewNonce { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pq);
			writer.Write(P);
			writer.Write(Q);
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
			var sizeNewNonce = NewNonce.GetByteCount();
			if(sizeNewNonce != 32){
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