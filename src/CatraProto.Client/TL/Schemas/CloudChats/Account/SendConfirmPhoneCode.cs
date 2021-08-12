using System;
using System.Text.Json.Serialization;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SendConfirmPhoneCode : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 457157256; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(SentCodeBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("hash")]
		public string Hash { get; set; }

[JsonPropertyName("settings")]
		public CodeSettingsBase Settings { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<string>();
			Settings = reader.Read<CodeSettingsBase>();
		}

		public override string ToString()
		{
			return "account.sendConfirmPhoneCode";
		}
	}
}