using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ClientDHInnerData : CatraProto.Client.TL.Schemas.MTProto.ClientDHInnerDataBase
	{


        public static int StaticConstructorId { get => 1715713620; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("nonce")]
		public override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("retry_id")]
		public override long RetryId { get; set; }

[Newtonsoft.Json.JsonProperty("g_b")]
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
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			RetryId = reader.Read<long>();
			GB = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "client_DH_inner_data";
		}
	}
}