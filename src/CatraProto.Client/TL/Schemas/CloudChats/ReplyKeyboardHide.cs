using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReplyKeyboardHide : ReplyMarkupBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Selective = 1 << 2
		}

		public static int ConstructorId { get; } = -1606526075;
		public int Flags { get; set; }
		public bool Selective { get; set; }

		public override void UpdateFlags()
		{
			Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
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
			Selective = FlagsHelper.IsFlagSet(Flags, 2);
		}
	}
}