using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SendConfirmPhoneCode : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 457157256; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("hash")]
		public string Hash { get; set; }

[JsonPropertyName("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase Settings { get; set; }


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
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase>();

		}
	}
}