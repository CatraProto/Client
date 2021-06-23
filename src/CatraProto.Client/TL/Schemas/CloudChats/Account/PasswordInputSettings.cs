using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class PasswordInputSettings : PasswordInputSettingsBase
	{
		public static int ConstructorId { get; } = -1036572727;
		public int Flags { get; set; }
		public override PasswordKdfAlgoBase NewAlgo { get; set; }
		public override byte[] NewPasswordHash { get; set; }
		public override string Hint { get; set; }
		public override string Email { get; set; }
		public override SecureSecretSettingsBase NewSecureSettings { get; set; }

		[Flags]
		public enum FlagsEnum
		{
			NewAlgo = 1 << 0,
			NewPasswordHash = 1 << 0,
			Hint = 1 << 0,
			Email = 1 << 1,
			NewSecureSettings = 1 << 2
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
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(NewAlgo);
			}

			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(NewPasswordHash);
			}

			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Hint);
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Email);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(NewSecureSettings);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				NewAlgo = reader.Read<PasswordKdfAlgoBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				NewPasswordHash = reader.Read<byte[]>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				Hint = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				Email = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				NewSecureSettings = reader.Read<SecureSecretSettingsBase>();
			}
		}
	}
}