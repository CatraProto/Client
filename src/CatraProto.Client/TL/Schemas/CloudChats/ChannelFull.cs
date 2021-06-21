using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelFull : ChatFullBase
	{
		[Flags]
		public enum FlagsEnum
		{
			CanViewParticipants = 1 << 3,
			CanSetUsername = 1 << 7,
			CanSetStickers = 1 << 7,
			HiddenPrehistory = 1 << 10,
			CanSetLocation = 1 << 16,
			HasScheduled = 1 << 8,
			CanViewStats = 1 << 20,
			Blocked = 1 << 22,
			ParticipantsCount = 1 << 0,
			AdminsCount = 1 << 1,
			KickedCount = 1 << 2,
			BannedCount = 1 << 2,
			OnlineCount = 1 << 13,
			ChatPhoto = 1 << 2,
			BotInfo = 1 << 3,
			MigratedFromChatId = 1 << 4,
			MigratedFromMaxId = 1 << 4,
			PinnedMsgId = 1 << 6,
			Stickerset = 1 << 8,
			AvailableMinId = 1 << 9,
			FolderId = 1 << 11,
			LinkedChatId = 1 << 14,
			Location = 1 << 15,
			SlowmodeSeconds = 1 << 17,
			SlowmodeNextSendDate = 1 << 18,
			StatsDc = 1 << 12
		}

		public static int ConstructorId { get; } = -253335766;
		public int Flags { get; set; }
		public bool CanViewParticipants { get; set; }
		public override bool CanSetUsername { get; set; }
		public bool CanSetStickers { get; set; }
		public bool HiddenPrehistory { get; set; }
		public bool CanSetLocation { get; set; }
		public override bool HasScheduled { get; set; }
		public bool CanViewStats { get; set; }
		public bool Blocked { get; set; }
		public override int Id { get; set; }
		public override string About { get; set; }
		public int? ParticipantsCount { get; set; }
		public int? AdminsCount { get; set; }
		public int? KickedCount { get; set; }
		public int? BannedCount { get; set; }
		public int? OnlineCount { get; set; }
		public int ReadInboxMaxId { get; set; }
		public int ReadOutboxMaxId { get; set; }
		public int UnreadCount { get; set; }
		public override PhotoBase ChatPhoto { get; set; }
		public override PeerNotifySettingsBase NotifySettings { get; set; }
		public override ExportedChatInviteBase ExportedInvite { get; set; }
		public override IList<BotInfoBase> BotInfo { get; set; }
		public int? MigratedFromChatId { get; set; }
		public int? MigratedFromMaxId { get; set; }
		public override int? PinnedMsgId { get; set; }
		public StickerSetBase Stickerset { get; set; }
		public int? AvailableMinId { get; set; }
		public override int? FolderId { get; set; }
		public int? LinkedChatId { get; set; }
		public ChannelLocationBase Location { get; set; }
		public int? SlowmodeSeconds { get; set; }
		public int? SlowmodeNextSendDate { get; set; }
		public int? StatsDc { get; set; }
		public int Pts { get; set; }

		public override void UpdateFlags()
		{
			Flags = CanViewParticipants ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = CanSetUsername ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = CanSetStickers ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = HiddenPrehistory ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = CanSetLocation ? FlagsHelper.SetFlag(Flags, 16) : FlagsHelper.UnsetFlag(Flags, 16);
			Flags = HasScheduled ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = CanViewStats ? FlagsHelper.SetFlag(Flags, 20) : FlagsHelper.UnsetFlag(Flags, 20);
			Flags = Blocked ? FlagsHelper.SetFlag(Flags, 22) : FlagsHelper.UnsetFlag(Flags, 22);
			Flags = ParticipantsCount == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = AdminsCount == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = KickedCount == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = BannedCount == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = OnlineCount == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
			Flags = ChatPhoto == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = BotInfo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = MigratedFromChatId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = MigratedFromMaxId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = PinnedMsgId == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = Stickerset == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
			Flags = AvailableMinId == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = LinkedChatId == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = Location == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);
			Flags = SlowmodeSeconds == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);
			Flags = SlowmodeNextSendDate == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);
			Flags = StatsDc == null ? FlagsHelper.UnsetFlag(Flags, 12) : FlagsHelper.SetFlag(Flags, 12);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(About);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ParticipantsCount.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(AdminsCount.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(KickedCount.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(BannedCount.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 13))
			{
				writer.Write(OnlineCount.Value);
			}

			writer.Write(ReadInboxMaxId);
			writer.Write(ReadOutboxMaxId);
			writer.Write(UnreadCount);
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ChatPhoto);
			}

			writer.Write(NotifySettings);
			writer.Write(ExportedInvite);
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(BotInfo);
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(MigratedFromChatId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(MigratedFromMaxId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(PinnedMsgId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 8))
			{
				writer.Write(Stickerset);
			}

			if (FlagsHelper.IsFlagSet(Flags, 9))
			{
				writer.Write(AvailableMinId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(FolderId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 14))
			{
				writer.Write(LinkedChatId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 15))
			{
				writer.Write(Location);
			}

			if (FlagsHelper.IsFlagSet(Flags, 17))
			{
				writer.Write(SlowmodeSeconds.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 18))
			{
				writer.Write(SlowmodeNextSendDate.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 12))
			{
				writer.Write(StatsDc.Value);
			}

			writer.Write(Pts);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CanViewParticipants = FlagsHelper.IsFlagSet(Flags, 3);
			CanSetUsername = FlagsHelper.IsFlagSet(Flags, 7);
			CanSetStickers = FlagsHelper.IsFlagSet(Flags, 7);
			HiddenPrehistory = FlagsHelper.IsFlagSet(Flags, 10);
			CanSetLocation = FlagsHelper.IsFlagSet(Flags, 16);
			HasScheduled = FlagsHelper.IsFlagSet(Flags, 8);
			CanViewStats = FlagsHelper.IsFlagSet(Flags, 20);
			Blocked = FlagsHelper.IsFlagSet(Flags, 22);
			Id = reader.Read<int>();
			About = reader.Read<string>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				ParticipantsCount = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				AdminsCount = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				KickedCount = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				BannedCount = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 13))
			{
				OnlineCount = reader.Read<int>();
			}

			ReadInboxMaxId = reader.Read<int>();
			ReadOutboxMaxId = reader.Read<int>();
			UnreadCount = reader.Read<int>();
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				ChatPhoto = reader.Read<PhotoBase>();
			}

			NotifySettings = reader.Read<PeerNotifySettingsBase>();
			ExportedInvite = reader.Read<ExportedChatInviteBase>();
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				BotInfo = reader.ReadVector<BotInfoBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				MigratedFromChatId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				MigratedFromMaxId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 6))
			{
				PinnedMsgId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 8))
			{
				Stickerset = reader.Read<StickerSetBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 9))
			{
				AvailableMinId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				FolderId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 14))
			{
				LinkedChatId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 15))
			{
				Location = reader.Read<ChannelLocationBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 17))
			{
				SlowmodeSeconds = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 18))
			{
				SlowmodeNextSendDate = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 12))
			{
				StatsDc = reader.Read<int>();
			}

			Pts = reader.Read<int>();
		}
	}
}