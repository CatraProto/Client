using System.Collections.Generic;
using System.Numerics;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ResPQ : ResPQBase
	{


        public static int StaticConstructorId { get => 85337187; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("nonce")]
		public override BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public override BigInteger ServerNonce { get; set; }

[JsonPropertyName("pq")]
		public override byte[] Pq { get; set; }

[JsonPropertyName("server_public_key_fingerprints")]
		public override IList<long> ServerPublicKeyFingerprints { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(Pq);
			writer.Write(ServerPublicKeyFingerprints);

		}

		public override void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			Pq = reader.Read<byte[]>();
			ServerPublicKeyFingerprints = reader.ReadVector<long>();
		}

		public override string ToString()
		{
			return "resPQ";
		}
	}
}