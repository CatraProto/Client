using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventsFilter : ChannelAdminLogEventsFilterBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Join = 1 << 0,
			Leave = 1 << 1,
			Invite = 1 << 2,
			Ban = 1 << 3,
			Unban = 1 << 4,
			Kick = 1 << 5,
			Unkick = 1 << 6,
			Promote = 1 << 7,
			Demote = 1 << 8,
			Info = 1 << 9,
			Settings = 1 << 10,
			Pinned = 1 << 11,
			Edit = 1 << 12,
			Delete = 1 << 13,
			GroupCall = 1 << 14,
			Invites = 1 << 15
		}

		public static int ConstructorId { get; } = -368018716;
		public int Flags { get; set; }
		public override bool Join { get; set; }
		public override bool Leave { get; set; }
		public override bool Invite { get; set; }
		public override bool Ban { get; set; }
		public override bool Unban { get; set; }
		public override bool Kick { get; set; }
		public override bool Unkick { get; set; }
		public override bool Promote { get; set; }
		public override bool Demote { get; set; }
		public override bool Info { get; set; }
		public override bool Settings { get; set; }
		public override bool Pinned { get; set; }
		public override bool Edit { get; set; }
		public override bool Delete { get; set; }
		public override bool GroupCall { get; set; }
		public override bool Invites { get; set; }

		public override void UpdateFlags()
		{
			Flags = Join ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Leave ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Invite ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Ban ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Unban ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Kick ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Unkick ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = Promote ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = Demote ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = Info ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
			Flags = Settings ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = Pinned ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
			Flags = Edit ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
			Flags = Delete ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
			Flags = GroupCall ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
			Flags = Invites ? FlagsHelper.SetFlag(Flags, 15) : FlagsHelper.UnsetFlag(Flags, 15);
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
			Join = FlagsHelper.IsFlagSet(Flags, 0);
			Leave = FlagsHelper.IsFlagSet(Flags, 1);
			Invite = FlagsHelper.IsFlagSet(Flags, 2);
			Ban = FlagsHelper.IsFlagSet(Flags, 3);
			Unban = FlagsHelper.IsFlagSet(Flags, 4);
			Kick = FlagsHelper.IsFlagSet(Flags, 5);
			Unkick = FlagsHelper.IsFlagSet(Flags, 6);
			Promote = FlagsHelper.IsFlagSet(Flags, 7);
			Demote = FlagsHelper.IsFlagSet(Flags, 8);
			Info = FlagsHelper.IsFlagSet(Flags, 9);
			Settings = FlagsHelper.IsFlagSet(Flags, 10);
			Pinned = FlagsHelper.IsFlagSet(Flags, 11);
			Edit = FlagsHelper.IsFlagSet(Flags, 12);
			Delete = FlagsHelper.IsFlagSet(Flags, 13);
			GroupCall = FlagsHelper.IsFlagSet(Flags, 14);
			Invites = FlagsHelper.IsFlagSet(Flags, 15);
		}
	}
}