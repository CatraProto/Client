using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DhGenOk : CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1003222836; }
        
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkNonce = writer.WriteBigInteger(Nonce);
if(checkNonce.IsError){ return checkNonce;}
var checkServerNonce = writer.WriteBigInteger(ServerNonce);
if(checkServerNonce.IsError){ return checkServerNonce;}
var checkNewNonceHash1 = writer.WriteBigInteger(NewNonceHash1);
if(checkNewNonceHash1.IsError){ return checkNewNonceHash1;}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trynonce = reader.ReadBigInteger(128);
if(trynonce.IsError){
return ReadResult<IObject>.Move(trynonce);
}
Nonce = trynonce.Value;
			var tryserverNonce = reader.ReadBigInteger(128);
if(tryserverNonce.IsError){
return ReadResult<IObject>.Move(tryserverNonce);
}
ServerNonce = tryserverNonce.Value;
			var trynewNonceHash1 = reader.ReadBigInteger(128);
if(trynewNonceHash1.IsError){
return ReadResult<IObject>.Move(trynewNonceHash1);
}
NewNonceHash1 = trynewNonceHash1.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "dh_gen_ok";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}