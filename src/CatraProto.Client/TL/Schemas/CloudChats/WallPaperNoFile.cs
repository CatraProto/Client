using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WallPaperNoFile : WallPaperBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Default = 1 << 1,
			Dark = 1 << 4,
			Settings = 1 << 2
		}

		public static int ConstructorId { get; } = -1963717851;
		public int Flags { get; set; }
		public override bool Default { get; set; }
		public override bool Dark { get; set; }
		public override WallPaperSettingsBase Settings { get; set; }

		public override void UpdateFlags()
		{
			Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Settings);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Default = FlagsHelper.IsFlagSet(Flags, 1);
			Dark = FlagsHelper.IsFlagSet(Flags, 4);
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				Settings = reader.Read<WallPaperSettingsBase>();
			}
		}
	}
}