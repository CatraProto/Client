using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class AcceptAuthorization : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -419267436; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("bot_id")]
		public int BotId { get; set; }

[JsonPropertyName("scope")]
		public string Scope { get; set; }

[JsonPropertyName("public_key")]
		public string PublicKey { get; set; }

[JsonPropertyName("value_hashes")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase> ValueHashes { get; set; }

[JsonPropertyName("credentials")]
		public CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase Credentials { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BotId);
			writer.Write(Scope);
			writer.Write(PublicKey);
			writer.Write(ValueHashes);
			writer.Write(Credentials);

		}

		public void Deserialize(Reader reader)
		{
			BotId = reader.Read<int>();
			Scope = reader.Read<string>();
			PublicKey = reader.Read<string>();
			ValueHashes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase>();
			Credentials = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase>();

		}
	}
}