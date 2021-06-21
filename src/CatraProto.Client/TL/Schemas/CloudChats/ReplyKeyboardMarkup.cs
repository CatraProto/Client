using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReplyKeyboardMarkup : ReplyMarkupBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Resize = 1 << 0,
			SingleUse = 1 << 1,
			Selective = 1 << 2
		}

		public static int ConstructorId { get; } = 889353612;
		public int Flags { get; set; }
		public bool Resize { get; set; }
		public bool SingleUse { get; set; }
		public bool Selective { get; set; }
		public IList<KeyboardButtonRowBase> Rows { get; set; }

		public override void UpdateFlags()
		{
			Flags = Resize ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = SingleUse ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Rows);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Resize = FlagsHelper.IsFlagSet(Flags, 0);
			SingleUse = FlagsHelper.IsFlagSet(Flags, 1);
			Selective = FlagsHelper.IsFlagSet(Flags, 2);
			Rows = reader.ReadVector<KeyboardButtonRowBase>();
		}
	}
}