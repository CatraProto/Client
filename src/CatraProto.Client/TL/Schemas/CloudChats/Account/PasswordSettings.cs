using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


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

        public static int ConstructorId { get; } = -1705233435;
		public int Flags { get; set; }
		public override string Email { get; set; }
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