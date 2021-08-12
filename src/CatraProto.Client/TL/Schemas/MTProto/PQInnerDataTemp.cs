using System.Numerics;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PQInnerDataTemp : PQInnerDataBase
	{


        public static int StaticConstructorId { get => 1013613780; }
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

[JsonPropertyName("expires_in")]
		public int ExpiresIn { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pq);
			writer.Write(P);
			writer.Write(Q);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(NewNonce);
			writer.Write(ExpiresIn);

		}

		public override void Deserialize(Reader reader)
		{
			Pq = reader.Read<byte[]>();
			P = reader.Read<byte[]>();
			Q = reader.Read<byte[]>();
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			NewNonce = reader.Read<BigInteger>(256);
			ExpiresIn = reader.Read<int>();
		}

		public override string ToString()
		{
			return "p_q_inner_data_temp";
		}
	}
}