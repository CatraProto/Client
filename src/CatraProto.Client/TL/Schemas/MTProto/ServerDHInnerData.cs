using System.Numerics;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ServerDHInnerData : ServerDHInnerDataBase
	{


        public static int StaticConstructorId { get => -1249309254; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("nonce")]
		public override BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public override BigInteger ServerNonce { get; set; }

[JsonPropertyName("g")]
		public override int G { get; set; }

[JsonPropertyName("dh_prime")]
		public override byte[] DhPrime { get; set; }

[JsonPropertyName("g_a")]
		public override byte[] GA { get; set; }

[JsonPropertyName("server_time")]
		public override int ServerTime { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(G);
			writer.Write(DhPrime);
			writer.Write(GA);
			writer.Write(ServerTime);

		}

		public override void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			G = reader.Read<int>();
			DhPrime = reader.Read<byte[]>();
			GA = reader.Read<byte[]>();
			ServerTime = reader.Read<int>();
		}

		public override string ToString()
		{
			return "server_DH_inner_data";
		}
	}
}