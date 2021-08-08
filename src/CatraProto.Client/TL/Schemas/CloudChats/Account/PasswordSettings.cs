using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class PasswordSettings : PasswordSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Email = 1 << 0,
			SecureSettings = 1 << 1
		}

        public static int StaticConstructorId { get => -1705233435; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("email")]
		public override string Email { get; set; }

[JsonPropertyName("secure_settings")]
		public override SecureSecretSettingsBase SecureSettings { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Email == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = SecureSettings == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Email);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(SecureSettings);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Email = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				SecureSettings = reader.Read<SecureSecretSettingsBase>();
			}


		}
	}
}