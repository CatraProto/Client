using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonUrlAuth : KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FwdText = 1 << 0
		}

        public static int ConstructorId { get; } = 280464681;
		public int Flags { get; set; }
		public override string Text { get; set; }
		public string FwdText { get; set; }
		public string Url { get; set; }
		public int ButtonId { get; set; }

		public override void UpdateFlags() 
		{
			Flags = FwdText == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Text);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FwdText);
			}

			writer.Write(Url);
			writer.Write(ButtonId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Text = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FwdText = reader.Read<string>();
			}

			Url = reader.Read<string>();
			ButtonId = reader.Read<int>();

		}
	}
}