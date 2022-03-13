using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DhGenOk : CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase
	{


        public static int StaticConstructorId { get => 1003222836; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("nonce")]
		public sealed override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("new_nonce_hash1")]
		public System.Numerics.BigInteger NewNonceHash1 { get; set; }


        #nullable enable
 public DhGenOk (System.Numerics.BigInteger nonce,System.Numerics.BigInteger serverNonce,System.Numerics.BigInteger newNonceHash1)
{
 Nonce = nonce;
ServerNonce = serverNonce;
NewNonceHash1 = newNonceHash1;
 
}
#nullable disable
        internal DhGenOk() 
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
			writer.Write(NewNonceHash1);

		}

		public override void Deserialize(Reader reader)
		{
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			NewNonceHash1 = reader.Read<System.Numerics.BigInteger>(128);

		}
				
		public override string ToString()
		{
		    return "dh_gen_ok";
		}
	}
}