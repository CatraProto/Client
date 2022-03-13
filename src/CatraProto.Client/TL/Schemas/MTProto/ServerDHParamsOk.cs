using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ServerDHParamsOk : CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase
	{


        public static int StaticConstructorId { get => -790100132; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("nonce")]
		public sealed override System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("encrypted_answer")]
		public byte[] EncryptedAnswer { get; set; }


        #nullable enable
 public ServerDHParamsOk (System.Numerics.BigInteger nonce,System.Numerics.BigInteger serverNonce,byte[] encryptedAnswer)
{
 Nonce = nonce;
ServerNonce = serverNonce;
EncryptedAnswer = encryptedAnswer;
 
}
#nullable disable
        internal ServerDHParamsOk() 
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
			writer.Write(EncryptedAnswer);

		}

		public override void Deserialize(Reader reader)
		{
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			EncryptedAnswer = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "server_DH_params_ok";
		}
	}
}