using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Password : PasswordBase
	{
		[Flags]
		public enum FlagsEnum
		{
			HasRecovery = 1 << 0,
			HasSecureValues = 1 << 1,
			HasPassword = 1 << 2,
			CurrentAlgo = 1 << 2,
			SrpB = 1 << 2,
			SrpId = 1 << 2,
			Hint = 1 << 3,
			EmailUnconfirmedPattern = 1 << 4
		}

		public static int ConstructorId { get; } = -1390001672;
		public int Flags { get; set; }
		public override bool HasRecovery { get; set; }
		public override bool HasSecureValues { get; set; }
		public override bool HasPassword { get; set; }
		public override PasswordKdfAlgoBase CurrentAlgo { get; set; }
		public override byte[] SrpB { get; set; }
		public override long? SrpId { get; set; }
		public override string Hint { get; set; }
		public override string EmailUnconfirmedPattern { get; set; }
		public override PasswordKdfAlgoBase NewAlgo { get; set; }
		public override SecurePasswordKdfAlgoBase NewSecureAlgo { get; set; }
		public override byte[] SecureRandom { get; set; }

		public override void UpdateFlags()
		{
			Flags = HasRecovery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = HasSecureValues ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = HasPassword ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = CurrentAlgo == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = SrpB == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = SrpId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Hint == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = EmailUnconfirmedPattern == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(CurrentAlgo);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(SrpB);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(SrpId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Hint);
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(EmailUnconfirmedPattern);
			}

			writer.Write(NewAlgo);
			writer.Write(NewSecureAlgo);
			writer.Write(SecureRandom);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasRecovery = FlagsHelper.IsFlagSet(Flags, 0);
			HasSecureValues = FlagsHelper.IsFlagSet(Flags, 1);
			HasPassword = FlagsHelper.IsFlagSet(Flags, 2);
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				CurrentAlgo = reader.Read<PasswordKdfAlgoBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				SrpB = reader.Read<byte[]>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				SrpId = reader.Read<long>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				Hint = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				EmailUnconfirmedPattern = reader.Read<string>();
			}

			NewAlgo = reader.Read<PasswordKdfAlgoBase>();
			NewSecureAlgo = reader.Read<SecurePasswordKdfAlgoBase>();
			SecureRandom = reader.Read<byte[]>();
		}
	}
}