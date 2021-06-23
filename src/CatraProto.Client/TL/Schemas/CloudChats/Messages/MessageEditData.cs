using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessageEditData : MessageEditDataBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Caption = 1 << 0
		}

		public static int ConstructorId { get; } = 649453030;
		public int Flags { get; set; }
		public override bool Caption { get; set; }

		public override void UpdateFlags()
		{
			Flags = Caption ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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
			Caption = FlagsHelper.IsFlagSet(Flags, 0);
		}
	}
}