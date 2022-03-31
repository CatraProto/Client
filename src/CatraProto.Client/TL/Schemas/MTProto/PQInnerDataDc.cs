using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PQInnerDataDc : CatraProto.Client.TL.Schemas.MTProto.PQInnerDataBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1443537003; }
        
[Newtonsoft.Json.JsonProperty("pq")]
		public sealed override byte[] Pq { get; set; }

[Newtonsoft.Json.JsonProperty("p")]
		public sealed override byte[] P { get; set; }

[Newtonsoft.Json.JsonProperty("q")]
		public sealed override byte[] Q { get; set; }

[Newtonsoft.Json.JsonProperty("nonce")]
		public sealed override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("new_nonce")]
		public sealed override System.Numerics.BigInteger NewNonce { get; set; }

[Newtonsoft.Json.JsonProperty("dc")]
		public sealed override int Dc { get; set; }


        #nullable enable
 public PQInnerDataDc (byte[] pq,byte[] p,byte[] q,System.Numerics.BigInteger nonce,System.Numerics.BigInteger serverNonce,System.Numerics.BigInteger newNonce,int dc)
{
 Pq = pq;
P = p;
Q = q;
Nonce = nonce;
ServerNonce = serverNonce;
NewNonce = newNonce;
Dc = dc;
 
}
#nullable disable
        internal PQInnerDataDc() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Pq);
			writer.Write(P);
			writer.Write(Q);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(NewNonce);
			writer.Write(Dc);

		}

		public override void Deserialize(Reader reader)
		{
			Pq = reader.Read<byte[]>();
			P = reader.Read<byte[]>();
			Q = reader.Read<byte[]>();
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			NewNonce = reader.Read<System.Numerics.BigInteger>(256);
			Dc = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "p_q_inner_data_dc";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}