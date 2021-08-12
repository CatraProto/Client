using System.Numerics;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ClientDHInnerData : ClientDHInnerDataBase
	{


        public static int StaticConstructorId { get => 1715713620; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("nonce")]
		public override BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public override BigInteger ServerNonce { get; set; }

[JsonPropertyName("retry_id")]
		public override long RetryId { get; set; }

[JsonPropertyName("g_b")]
		public override byte[] GB { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(RetryId);
			writer.Write(GB);

		}

		public override void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			RetryId = reader.Read<long>();
			GB = reader.Read<byte[]>();
		}

		public override string ToString()
		{
			return "client_DH_inner_data";
		}
	}
}