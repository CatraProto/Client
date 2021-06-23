using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonRequestPoll : KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Quiz = 1 << 0
		}

		public static int ConstructorId { get; } = -1144565411;
		public int Flags { get; set; }
		public bool? Quiz { get; set; }
		public override string Text { get; set; }

		public override void UpdateFlags()
		{
			Flags = Quiz == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Quiz.Value);
			writer.Write(Text);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Quiz = reader.Read<bool>();
			Text = reader.Read<string>();
		}
	}
}