using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ServerDHParamsFail : CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase
	{


        public static int StaticConstructorId { get => 2043348061; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("nonce")]
		public override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("new_nonce_hash")]
		public System.Numerics.BigInteger NewNonceHash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(NewNonceHash);

		}

		public override void Deserialize(Reader reader)
		{
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			NewNonceHash = reader.Read<System.Numerics.BigInteger>(128);

		}
				
		public override string ToString()
		{
		    return "server_DH_params_fail";
		}
	}
}