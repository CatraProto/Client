using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class BindTempAuthKey : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -841733627; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("perm_auth_key_id")]
		public long PermAuthKeyId { get; set; }

[Newtonsoft.Json.JsonProperty("nonce")]
		public long Nonce { get; set; }

[Newtonsoft.Json.JsonProperty("expires_at")]
		public int ExpiresAt { get; set; }

[Newtonsoft.Json.JsonProperty("encrypted_message")]
		public byte[] EncryptedMessage { get; set; }

        
        #nullable enable
 public BindTempAuthKey (long permAuthKeyId,long nonce,int expiresAt,byte[] encryptedMessage)
{
 PermAuthKeyId = permAuthKeyId;
Nonce = nonce;
ExpiresAt = expiresAt;
EncryptedMessage = encryptedMessage;
 
}
#nullable disable
                
        internal BindTempAuthKey() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PermAuthKeyId);
			writer.Write(Nonce);
			writer.Write(ExpiresAt);
			writer.Write(EncryptedMessage);

		}

		public void Deserialize(Reader reader)
		{
			PermAuthKeyId = reader.Read<long>();
			Nonce = reader.Read<long>();
			ExpiresAt = reader.Read<int>();
			EncryptedMessage = reader.Read<byte[]>();

		}

		public override string ToString()
		{
		    return "auth.bindTempAuthKey";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}