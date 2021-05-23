using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class CodeSettings : CodeSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			AllowFlashcall = 1 << 0,
			CurrentNumber = 1 << 1,
			AllowAppHash = 1 << 4
		}

        public static int ConstructorId { get; } = -557924733;
		public int Flags { get; set; }
		public override bool AllowFlashcall { get; set; }
		public override bool CurrentNumber { get; set; }
		public override bool AllowAppHash { get; set; }

		public override void UpdateFlags() 
		{
			Flags = AllowFlashcall ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = CurrentNumber ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = AllowAppHash ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			AllowFlashcall = FlagsHelper.IsFlagSet(Flags, 0);
			CurrentNumber = FlagsHelper.IsFlagSet(Flags, 1);
			AllowAppHash = FlagsHelper.IsFlagSet(Flags, 4);

		}
	}
}