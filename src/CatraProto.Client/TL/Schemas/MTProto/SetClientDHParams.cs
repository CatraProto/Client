using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class SetClientDHParams : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -184262881; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("nonce")]
		public System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("encrypted_data")]
		public byte[] EncryptedData { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(EncryptedData);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			EncryptedData = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "set_client_DH_params";
		}
	}
}