using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UnregisterDevice : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 813089983; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("token_type")]
		public int TokenType { get; set; }

[JsonPropertyName("token")]
		public string Token { get; set; }

[JsonPropertyName("other_uids")]
		public IList<int> OtherUids { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(TokenType);
			writer.Write(Token);
			writer.Write(OtherUids);

		}

		public void Deserialize(Reader reader)
		{
			TokenType = reader.Read<int>();
			Token = reader.Read<string>();
			OtherUids = reader.ReadVector<int>();

		}
	}
}