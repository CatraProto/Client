using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetAuthorizationForm : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1200903967; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("bot_id")]
		public int BotId { get; set; }

[JsonPropertyName("scope")]
		public string Scope { get; set; }

[JsonPropertyName("public_key")]
		public string PublicKey { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BotId);
			writer.Write(Scope);
			writer.Write(PublicKey);

		}

		public void Deserialize(Reader reader)
		{
			BotId = reader.Read<int>();
			Scope = reader.Read<string>();
			PublicKey = reader.Read<string>();

		}
	}
}