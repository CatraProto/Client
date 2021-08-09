using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PQInnerDataTemp : CatraProto.Client.TL.Schemas.MTProto.PQInnerDataBase
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
		public override System.Numerics.BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public override System.Numerics.BigInteger ServerNonce { get; set; }

[JsonPropertyName("new_nonce")]
		public override System.Numerics.BigInteger NewNonce { get; set; }

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
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			NewNonce = reader.Read<System.Numerics.BigInteger>(256);
			ExpiresIn = reader.Read<int>();

		}
	}
}