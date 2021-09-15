using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ResPQ : CatraProto.Client.TL.Schemas.MTProto.ResPQBase
	{


        public static int StaticConstructorId { get => 85337187; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("nonce")]
		public override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("pq")]
		public override byte[] Pq { get; set; }

[Newtonsoft.Json.JsonProperty("server_public_key_fingerprints")]
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
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			Pq = reader.Read<byte[]>();
			ServerPublicKeyFingerprints = reader.ReadVector<long>();

		}
				
		public override string ToString()
		{
		    return "resPQ";
		}
	}
}