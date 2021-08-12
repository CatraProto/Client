using System.Numerics;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DhGenFail : SetClientDHParamsAnswerBase
	{


        public static int StaticConstructorId { get => -1499615742; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("nonce")]
		public override BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public override BigInteger ServerNonce { get; set; }

[JsonPropertyName("new_nonce_hash3")]
		public BigInteger NewNonceHash3 { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(NewNonceHash3);

		}

		public override void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			NewNonceHash3 = reader.Read<BigInteger>(128);
		}

		public override string ToString()
		{
			return "dh_gen_fail";
		}
	}
}