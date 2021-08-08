using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdatePasswordSettings : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1516564433; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("password")]
		public InputCheckPasswordSRPBase Password { get; set; }

[JsonPropertyName("new_settings")]
		public PasswordInputSettingsBase NewSettings { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Password);
			writer.Write(NewSettings);

		}

		public void Deserialize(Reader reader)
		{
			Password = reader.Read<InputCheckPasswordSRPBase>();
			NewSettings = reader.Read<PasswordInputSettingsBase>();

		}
	}
}