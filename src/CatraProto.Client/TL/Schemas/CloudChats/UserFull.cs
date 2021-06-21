using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserFull : UserFullBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Blocked = 1 << 0,
			PhoneCallsAvailable = 1 << 4,
			PhoneCallsPrivate = 1 << 5,
			CanPinMessage = 1 << 7,
			HasScheduled = 1 << 12,
			VideoCallsAvailable = 1 << 13,
			About = 1 << 1,
			ProfilePhoto = 1 << 2,
			BotInfo = 1 << 3,
			PinnedMsgId = 1 << 6,
			FolderId = 1 << 11
		}

		public static int ConstructorId { get; } = -302941166;
		public int Flags { get; set; }
		public override bool Blocked { get; set; }
		public override bool PhoneCallsAvailable { get; set; }
		public override bool PhoneCallsPrivate { get; set; }
		public override bool CanPinMessage { get; set; }
		public override bool HasScheduled { get; set; }
		public override bool VideoCallsAvailable { get; set; }
		public override UserBase User { get; set; }
		public override string About { get; set; }
		public override PeerSettingsBase Settings { get; set; }
		public override PhotoBase ProfilePhoto { get; set; }
		public override PeerNotifySettingsBase NotifySettings { get; set; }
		public override BotInfoBase BotInfo { get; set; }
		public override int? PinnedMsgId { get; set; }
		public override int CommonChatsCount { get; set; }
		public override int? FolderId { get; set; }

		public override void UpdateFlags()
		{
			Flags = Blocked ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = PhoneCallsAvailable ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = PhoneCallsPrivate ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = CanPinMessage ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = HasScheduled ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
			Flags = VideoCallsAvailable ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
			Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ProfilePhoto == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = BotInfo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = PinnedMsgId == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(User);
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(About);
			}

			writer.Write(Settings);
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ProfilePhoto);
			}

			writer.Write(NotifySettings);
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(BotInfo);
			}

			if (FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(PinnedMsgId.Value);
			}

			writer.Write(CommonChatsCount);
			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(FolderId.Value);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Blocked = FlagsHelper.IsFlagSet(Flags, 0);
			PhoneCallsAvailable = FlagsHelper.IsFlagSet(Flags, 4);
			PhoneCallsPrivate = FlagsHelper.IsFlagSet(Flags, 5);
			CanPinMessage = FlagsHelper.IsFlagSet(Flags, 7);
			HasScheduled = FlagsHelper.IsFlagSet(Flags, 12);
			VideoCallsAvailable = FlagsHelper.IsFlagSet(Flags, 13);
			User = reader.Read<UserBase>();
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				About = reader.Read<string>();
			}

			Settings = reader.Read<PeerSettingsBase>();
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				ProfilePhoto = reader.Read<PhotoBase>();
			}

			NotifySettings = reader.Read<PeerNotifySettingsBase>();
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				BotInfo = reader.Read<BotInfoBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 6))
			{
				PinnedMsgId = reader.Read<int>();
			}

			CommonChatsCount = reader.Read<int>();
			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				FolderId = reader.Read<int>();
			}
		}
	}
}