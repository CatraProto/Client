using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveAutoDownloadSettings : IMethod<bool>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Low = 1 << 0,
			High = 1 << 1
		}

        public static int ConstructorId { get; } = 1995661875;

		public int Flags { get; set; }
		public bool Low { get; set; }
		public bool High { get; set; }
		public AutoDownloadSettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{
			Flags = Low ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = High ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Low = FlagsHelper.IsFlagSet(Flags, 0);
			High = FlagsHelper.IsFlagSet(Flags, 1);
			Settings = reader.Read<AutoDownloadSettingsBase>();

		}
	}
}