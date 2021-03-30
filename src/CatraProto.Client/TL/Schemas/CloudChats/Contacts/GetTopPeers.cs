using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class GetTopPeers : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Correspondents = 1 << 0,
			BotsPm = 1 << 1,
			BotsInline = 1 << 2,
			PhoneCalls = 1 << 3,
			ForwardUsers = 1 << 4,
			ForwardChats = 1 << 5,
			Groups = 1 << 10,
			Channels = 1 << 15
		}

        public static int ConstructorId { get; } = -728224331;

		public int Flags { get; set; }
		public bool Correspondents { get; set; }
		public bool BotsPm { get; set; }
		public bool BotsInline { get; set; }
		public bool PhoneCalls { get; set; }
		public bool ForwardUsers { get; set; }
		public bool ForwardChats { get; set; }
		public bool Groups { get; set; }
		public bool Channels { get; set; }
		public int Offset { get; set; }
		public int Limit { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{
			Flags = Correspondents ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = BotsPm ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = BotsInline ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = PhoneCalls ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = ForwardUsers ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = ForwardChats ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Groups ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = Channels ? FlagsHelper.SetFlag(Flags, 15) : FlagsHelper.UnsetFlag(Flags, 15);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Offset);
			writer.Write(Limit);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Correspondents = FlagsHelper.IsFlagSet(Flags, 0);
			BotsPm = FlagsHelper.IsFlagSet(Flags, 1);
			BotsInline = FlagsHelper.IsFlagSet(Flags, 2);
			PhoneCalls = FlagsHelper.IsFlagSet(Flags, 3);
			ForwardUsers = FlagsHelper.IsFlagSet(Flags, 4);
			ForwardChats = FlagsHelper.IsFlagSet(Flags, 5);
			Groups = FlagsHelper.IsFlagSet(Flags, 10);
			Channels = FlagsHelper.IsFlagSet(Flags, 15);
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();
			Hash = reader.Read<int>();

		}
	}
}