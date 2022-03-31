using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class PasswordInputSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NewAlgo = 1 << 0,
			NewPasswordHash = 1 << 0,
			Hint = 1 << 0,
			Email = 1 << 1,
			NewSecureSettings = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1036572727; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("new_algo")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

[Newtonsoft.Json.JsonProperty("new_password_hash")]
		public sealed override byte[] NewPasswordHash { get; set; }

[Newtonsoft.Json.JsonProperty("hint")]
		public sealed override string Hint { get; set; }

[Newtonsoft.Json.JsonProperty("email")]
		public sealed override string Email { get; set; }

[Newtonsoft.Json.JsonProperty("new_secure_settings")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase NewSecureSettings { get; set; }


        
        public PasswordInputSettings() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = NewAlgo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = NewPasswordHash == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Hint == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Email == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = NewSecureSettings == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(NewAlgo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(NewPasswordHash);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Hint);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Email);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(NewSecureSettings);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				NewAlgo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				NewPasswordHash = reader.Read<byte[]>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Hint = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Email = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				NewSecureSettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase>();
			}


		}
		
		public override string ToString()
		{
		    return "account.passwordInputSettings";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}