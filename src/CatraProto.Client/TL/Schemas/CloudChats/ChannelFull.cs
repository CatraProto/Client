using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelFull : CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CanViewParticipants = 1 << 3,
			CanSetUsername = 1 << 6,
			CanSetStickers = 1 << 7,
			HiddenPrehistory = 1 << 10,
			CanSetLocation = 1 << 16,
			HasScheduled = 1 << 19,
			CanViewStats = 1 << 20,
			Blocked = 1 << 22,
			ParticipantsCount = 1 << 0,
			AdminsCount = 1 << 1,
			KickedCount = 1 << 2,
			BannedCount = 1 << 2,
			OnlineCount = 1 << 13,
			ExportedInvite = 1 << 23,
			MigratedFromChatId = 1 << 4,
			MigratedFromMaxId = 1 << 4,
			PinnedMsgId = 1 << 5,
			Stickerset = 1 << 8,
			AvailableMinId = 1 << 9,
			FolderId = 1 << 11,
			LinkedChatId = 1 << 14,
			Location = 1 << 15,
			SlowmodeSeconds = 1 << 17,
			SlowmodeNextSendDate = 1 << 18,
			StatsDc = 1 << 12,
			Call = 1 << 21,
			TtlPeriod = 1 << 24,
			PendingSuggestions = 1 << 25,
			GroupcallDefaultJoinAs = 1 << 26,
			ThemeEmoticon = 1 << 27,
			RequestsPending = 1 << 28,
			RecentRequesters = 1 << 28,
			DefaultSendAs = 1 << 29
		}

        public static int StaticConstructorId { get => 1449537070; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("can_view_participants")]
		public bool CanViewParticipants { get; set; }

[Newtonsoft.Json.JsonProperty("can_set_username")]
		public bool CanSetUsername { get; set; }

[Newtonsoft.Json.JsonProperty("can_set_stickers")]
		public bool CanSetStickers { get; set; }

[Newtonsoft.Json.JsonProperty("hidden_prehistory")]
		public bool HiddenPrehistory { get; set; }

[Newtonsoft.Json.JsonProperty("can_set_location")]
		public bool CanSetLocation { get; set; }

[Newtonsoft.Json.JsonProperty("has_scheduled")]
		public bool HasScheduled { get; set; }

[Newtonsoft.Json.JsonProperty("can_view_stats")]
		public bool CanViewStats { get; set; }

[Newtonsoft.Json.JsonProperty("blocked")]
		public bool Blocked { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("about")]
		public override string About { get; set; }

[Newtonsoft.Json.JsonProperty("participants_count")]
		public int? ParticipantsCount { get; set; }

[Newtonsoft.Json.JsonProperty("admins_count")]
		public int? AdminsCount { get; set; }

[Newtonsoft.Json.JsonProperty("kicked_count")]
		public int? KickedCount { get; set; }

[Newtonsoft.Json.JsonProperty("banned_count")]
		public int? BannedCount { get; set; }

[Newtonsoft.Json.JsonProperty("online_count")]
		public int? OnlineCount { get; set; }

[Newtonsoft.Json.JsonProperty("read_inbox_max_id")]
		public int ReadInboxMaxId { get; set; }

[Newtonsoft.Json.JsonProperty("read_outbox_max_id")]
		public int ReadOutboxMaxId { get; set; }

[Newtonsoft.Json.JsonProperty("unread_count")]
		public int UnreadCount { get; set; }

[Newtonsoft.Json.JsonProperty("chat_photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ChatPhoto { get; set; }

[Newtonsoft.Json.JsonProperty("notify_settings")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

[Newtonsoft.Json.JsonProperty("exported_invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase ExportedInvite { get; set; }

[Newtonsoft.Json.JsonProperty("bot_info")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase> BotInfo { get; set; }

[Newtonsoft.Json.JsonProperty("migrated_from_chat_id")]
		public long? MigratedFromChatId { get; set; }

[Newtonsoft.Json.JsonProperty("migrated_from_max_id")]
		public int? MigratedFromMaxId { get; set; }

[Newtonsoft.Json.JsonProperty("pinned_msg_id")]
		public int? PinnedMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Stickerset { get; set; }

[Newtonsoft.Json.JsonProperty("available_min_id")]
		public int? AvailableMinId { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public override int? FolderId { get; set; }

[Newtonsoft.Json.JsonProperty("linked_chat_id")]
		public long? LinkedChatId { get; set; }

[Newtonsoft.Json.JsonProperty("location")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase Location { get; set; }

[Newtonsoft.Json.JsonProperty("slowmode_seconds")]
		public int? SlowmodeSeconds { get; set; }

[Newtonsoft.Json.JsonProperty("slowmode_next_send_date")]
		public int? SlowmodeNextSendDate { get; set; }

[Newtonsoft.Json.JsonProperty("stats_dc")]
		public int? StatsDc { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("ttl_period")]
		public int? TtlPeriod { get; set; }

[Newtonsoft.Json.JsonProperty("pending_suggestions")]
		public IList<string> PendingSuggestions { get; set; }

[Newtonsoft.Json.JsonProperty("groupcall_default_join_as")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase GroupcallDefaultJoinAs { get; set; }

[Newtonsoft.Json.JsonProperty("theme_emoticon")]
		public string ThemeEmoticon { get; set; }

[Newtonsoft.Json.JsonProperty("requests_pending")]
		public int? RequestsPending { get; set; }

[Newtonsoft.Json.JsonProperty("recent_requesters")]
		public IList<long> RecentRequesters { get; set; }

[Newtonsoft.Json.JsonProperty("default_send_as")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase DefaultSendAs { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = CanViewParticipants ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = CanSetUsername ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = CanSetStickers ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = HiddenPrehistory ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = CanSetLocation ? FlagsHelper.SetFlag(Flags, 16) : FlagsHelper.UnsetFlag(Flags, 16);
			Flags = HasScheduled ? FlagsHelper.SetFlag(Flags, 19) : FlagsHelper.UnsetFlag(Flags, 19);
			Flags = CanViewStats ? FlagsHelper.SetFlag(Flags, 20) : FlagsHelper.UnsetFlag(Flags, 20);
			Flags = Blocked ? FlagsHelper.SetFlag(Flags, 22) : FlagsHelper.UnsetFlag(Flags, 22);
			Flags = ParticipantsCount == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = AdminsCount == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = KickedCount == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = BannedCount == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = OnlineCount == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
			Flags = ExportedInvite == null ? FlagsHelper.UnsetFlag(Flags, 23) : FlagsHelper.SetFlag(Flags, 23);
			Flags = MigratedFromChatId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = MigratedFromMaxId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = PinnedMsgId == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
			Flags = Stickerset == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
			Flags = AvailableMinId == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = LinkedChatId == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = Location == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);
			Flags = SlowmodeSeconds == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);
			Flags = SlowmodeNextSendDate == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);
			Flags = StatsDc == null ? FlagsHelper.UnsetFlag(Flags, 12) : FlagsHelper.SetFlag(Flags, 12);
			Flags = Call == null ? FlagsHelper.UnsetFlag(Flags, 21) : FlagsHelper.SetFlag(Flags, 21);
			Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 24) : FlagsHelper.SetFlag(Flags, 24);
			Flags = PendingSuggestions == null ? FlagsHelper.UnsetFlag(Flags, 25) : FlagsHelper.SetFlag(Flags, 25);
			Flags = GroupcallDefaultJoinAs == null ? FlagsHelper.UnsetFlag(Flags, 26) : FlagsHelper.SetFlag(Flags, 26);
			Flags = ThemeEmoticon == null ? FlagsHelper.UnsetFlag(Flags, 27) : FlagsHelper.SetFlag(Flags, 27);
			Flags = RequestsPending == null ? FlagsHelper.UnsetFlag(Flags, 28) : FlagsHelper.SetFlag(Flags, 28);
			Flags = RecentRequesters == null ? FlagsHelper.UnsetFlag(Flags, 28) : FlagsHelper.SetFlag(Flags, 28);
			Flags = DefaultSendAs == null ? FlagsHelper.UnsetFlag(Flags, 29) : FlagsHelper.SetFlag(Flags, 29);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(About);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ParticipantsCount.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(AdminsCount.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(KickedCount.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(BannedCount.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 13))
			{
				writer.Write(OnlineCount.Value);
			}

			writer.Write(ReadInboxMaxId);
			writer.Write(ReadOutboxMaxId);
			writer.Write(UnreadCount);
			writer.Write(ChatPhoto);
			writer.Write(NotifySettings);
			if(FlagsHelper.IsFlagSet(Flags, 23))
			{
				writer.Write(ExportedInvite);
			}

			writer.Write(BotInfo);
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(MigratedFromChatId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(MigratedFromMaxId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(PinnedMsgId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				writer.Write(Stickerset);
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				writer.Write(AvailableMinId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(FolderId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				writer.Write(LinkedChatId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				writer.Write(Location);
			}

			if(FlagsHelper.IsFlagSet(Flags, 17))
			{
				writer.Write(SlowmodeSeconds.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 18))
			{
				writer.Write(SlowmodeNextSendDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 12))
			{
				writer.Write(StatsDc.Value);
			}

			writer.Write(Pts);
			if(FlagsHelper.IsFlagSet(Flags, 21))
			{
				writer.Write(Call);
			}

			if(FlagsHelper.IsFlagSet(Flags, 24))
			{
				writer.Write(TtlPeriod.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 25))
			{
				writer.Write(PendingSuggestions);
			}

			if(FlagsHelper.IsFlagSet(Flags, 26))
			{
				writer.Write(GroupcallDefaultJoinAs);
			}

			if(FlagsHelper.IsFlagSet(Flags, 27))
			{
				writer.Write(ThemeEmoticon);
			}

			if(FlagsHelper.IsFlagSet(Flags, 28))
			{
				writer.Write(RequestsPending.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 28))
			{
				writer.Write(RecentRequesters);
			}

			if(FlagsHelper.IsFlagSet(Flags, 29))
			{
				writer.Write(DefaultSendAs);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CanViewParticipants = FlagsHelper.IsFlagSet(Flags, 3);
			CanSetUsername = FlagsHelper.IsFlagSet(Flags, 6);
			CanSetStickers = FlagsHelper.IsFlagSet(Flags, 7);
			HiddenPrehistory = FlagsHelper.IsFlagSet(Flags, 10);
			CanSetLocation = FlagsHelper.IsFlagSet(Flags, 16);
			HasScheduled = FlagsHelper.IsFlagSet(Flags, 19);
			CanViewStats = FlagsHelper.IsFlagSet(Flags, 20);
			Blocked = FlagsHelper.IsFlagSet(Flags, 22);
			Id = reader.Read<long>();
			About = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ParticipantsCount = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				AdminsCount = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				KickedCount = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				BannedCount = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 13))
			{
				OnlineCount = reader.Read<int>();
			}

			ReadInboxMaxId = reader.Read<int>();
			ReadOutboxMaxId = reader.Read<int>();
			UnreadCount = reader.Read<int>();
			ChatPhoto = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			NotifySettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
			if(FlagsHelper.IsFlagSet(Flags, 23))
			{
				ExportedInvite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
			}

			BotInfo = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>();
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				MigratedFromChatId = reader.Read<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				MigratedFromMaxId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				PinnedMsgId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				AvailableMinId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				FolderId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				LinkedChatId = reader.Read<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				Location = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 17))
			{
				SlowmodeSeconds = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 18))
			{
				SlowmodeNextSendDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 12))
			{
				StatsDc = reader.Read<int>();
			}

			Pts = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 21))
			{
				Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 24))
			{
				TtlPeriod = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 25))
			{
				PendingSuggestions = reader.ReadVector<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 26))
			{
				GroupcallDefaultJoinAs = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 27))
			{
				ThemeEmoticon = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 28))
			{
				RequestsPending = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 28))
			{
				RecentRequesters = reader.ReadVector<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 29))
			{
				DefaultSendAs = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			}


		}
				
		public override string ToString()
		{
		    return "channelFull";
		}
	}
}