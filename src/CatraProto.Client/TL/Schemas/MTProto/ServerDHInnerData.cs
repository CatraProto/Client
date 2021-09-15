using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ServerDHInnerData : CatraProto.Client.TL.Schemas.MTProto.ServerDHInnerDataBase
	{


        public static int StaticConstructorId { get => -1249309254; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("nonce")]
		public override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("g")]
		public override int G { get; set; }

[Newtonsoft.Json.JsonProperty("dh_prime")]
		public override byte[] DhPrime { get; set; }

[Newtonsoft.Json.JsonProperty("g_a")]
		public override byte[] GA { get; set; }

[Newtonsoft.Json.JsonProperty("server_time")]
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
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
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