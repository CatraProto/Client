using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PQInnerDataTemp : CatraProto.Client.TL.Schemas.MTProto.PQInnerDataBase
	{


        public static int StaticConstructorId { get => 1013613780; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("pq")]
		public override byte[] Pq { get; set; }

[Newtonsoft.Json.JsonProperty("p")]
		public override byte[] P { get; set; }

[Newtonsoft.Json.JsonProperty("q")]
		public override byte[] Q { get; set; }

[Newtonsoft.Json.JsonProperty("nonce")]
		public override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("new_nonce")]
		public override System.Numerics.BigInteger NewNonce { get; set; }

[Newtonsoft.Json.JsonProperty("expires_in")]
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
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			NewNonce = reader.Read<System.Numerics.BigInteger>(256);
			ExpiresIn = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "p_q_inner_data_temp";
		}
	}
}