using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetGlobalPrivacySettings : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 517647042; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(GlobalPrivacySettingsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("settings")]
		public GlobalPrivacySettingsBase Settings { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Settings = reader.Read<GlobalPrivacySettingsBase>();
		}

		public override string ToString()
		{
			return "account.setGlobalPrivacySettings";
		}
	}
}