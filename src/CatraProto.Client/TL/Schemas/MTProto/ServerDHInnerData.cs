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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1249309254; }
        
[Newtonsoft.Json.JsonProperty("nonce")]
		public sealed override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("g")]
		public sealed override int G { get; set; }

[Newtonsoft.Json.JsonProperty("dh_prime")]
		public sealed override byte[] DhPrime { get; set; }

[Newtonsoft.Json.JsonProperty("g_a")]
		public sealed override byte[] GA { get; set; }

[Newtonsoft.Json.JsonProperty("server_time")]
		public sealed override int ServerTime { get; set; }


        #nullable enable
 public ServerDHInnerData (System.Numerics.BigInteger nonce,System.Numerics.BigInteger serverNonce,int g,byte[] dhPrime,byte[] gA,int serverTime)
{
 Nonce = nonce;
ServerNonce = serverNonce;
G = g;
DhPrime = dhPrime;
GA = gA;
ServerTime = serverTime;
 
}
#nullable disable
        internal ServerDHInnerData() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}