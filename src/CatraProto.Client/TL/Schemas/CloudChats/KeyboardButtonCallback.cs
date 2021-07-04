using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonCallback : KeyboardButtonBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			RequiresPassword = 1 << 0
		}

        public static int ConstructorId { get; } = 901503851;
		public int Flags { get; set; }
		public bool RequiresPassword { get; set; }
		public override string Text { get; set; }
		public byte[] Data { get; set; }

		public override void UpdateFlags() 
		{
			Flags = RequiresPassword ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Text);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			RequiresPassword = FlagsHelper.IsFlagSet(Flags, 0);
			Text = reader.Read<string>();
			Data = reader.Read<byte[]>();

		}
	}
}