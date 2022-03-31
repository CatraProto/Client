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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2043348061; }
        
[Newtonsoft.Json.JsonProperty("nonce")]
		public sealed override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("new_nonce_hash")]
		public System.Numerics.BigInteger NewNonceHash { get; set; }


        #nullable enable
 public ServerDHParamsFail (System.Numerics.BigInteger nonce,System.Numerics.BigInteger serverNonce,System.Numerics.BigInteger newNonceHash)
{
 Nonce = nonce;
ServerNonce = serverNonce;
NewNonceHash = newNonceHash;
 
}
#nullable disable
        internal ServerDHParamsFail() 
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}