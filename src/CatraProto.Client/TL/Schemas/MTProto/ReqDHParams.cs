using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ReqDHParams : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -686627650; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("nonce")]
		public System.Numerics.BigInteger Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("server_nonce")]
		public System.Numerics.BigInteger ServerNonce { get; set; }

[Newtonsoft.Json.JsonProperty("p")]
		public byte[] P { get; set; }

[Newtonsoft.Json.JsonProperty("q")]
		public byte[] Q { get; set; }

[Newtonsoft.Json.JsonProperty("public_key_fingerprint")]
		public long PublicKeyFingerprint { get; set; }

[Newtonsoft.Json.JsonProperty("encrypted_data")]
		public byte[] EncryptedData { get; set; }

        
        #nullable enable
 public ReqDHParams (System.Numerics.BigInteger nonce,System.Numerics.BigInteger serverNonce,byte[] p,byte[] q,long publicKeyFingerprint,byte[] encryptedData)
{
 Nonce = nonce;
ServerNonce = serverNonce;
P = p;
Q = q;
PublicKeyFingerprint = publicKeyFingerprint;
EncryptedData = encryptedData;
 
}
#nullable disable
                
        internal ReqDHParams() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(P);
			writer.Write(Q);
			writer.Write(PublicKeyFingerprint);
			writer.Write(EncryptedData);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			P = reader.Read<byte[]>();
			Q = reader.Read<byte[]>();
			PublicKeyFingerprint = reader.Read<long>();
			EncryptedData = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "req_DH_params";
		}
	}
}