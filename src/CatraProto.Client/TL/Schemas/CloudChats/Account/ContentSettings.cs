using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ContentSettings : ContentSettingsBase
	{
		[Flags]
		public enum FlagsEnum
		{
			SensitiveEnabled = 1 << 0,
			SensitiveCanChange = 1 << 1
		}

		public static int ConstructorId { get; } = 1474462241;
		public int Flags { get; set; }
		public override bool SensitiveEnabled { get; set; }
		public override bool SensitiveCanChange { get; set; }

		public override void UpdateFlags()
		{
			Flags = SensitiveEnabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = SensitiveCanChange ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			SensitiveEnabled = FlagsHelper.IsFlagSet(Flags, 0);
			SensitiveCanChange = FlagsHelper.IsFlagSet(Flags, 1);
		}
	}
}