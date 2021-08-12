using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class BindTempAuthKey : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -841733627; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("perm_auth_key_id")]
		public long PermAuthKeyId { get; set; }

[JsonPropertyName("nonce")]
		public long Nonce { get; set; }

[JsonPropertyName("expires_at")]
		public int ExpiresAt { get; set; }

[JsonPropertyName("encrypted_message")]
		public byte[] EncryptedMessage { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}