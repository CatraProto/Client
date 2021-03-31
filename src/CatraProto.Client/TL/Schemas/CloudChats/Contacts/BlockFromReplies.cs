using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class BlockFromReplies : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			DeleteMessage = 1 << 0,
			DeleteHistory = 1 << 1,
			ReportSpam = 1 << 2
		}

        public static int ConstructorId { get; } = 698914348;

		public int Flags { get; set; }
		public bool DeleteMessage { get; set; }
		public bool DeleteHistory { get; set; }
		public bool ReportSpam { get; set; }
		public int MsgId { get; set; }

		public void UpdateFlags() 
		{
			Flags = DeleteMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = DeleteHistory ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = ReportSpam ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(MsgId);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			DeleteMessage = FlagsHelper.IsFlagSet(Flags, 0);
			DeleteHistory = FlagsHelper.IsFlagSet(Flags, 1);
			ReportSpam = FlagsHelper.IsFlagSet(Flags, 2);
			MsgId = reader.Read<int>();

		}
	}
}