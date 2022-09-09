using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
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
            DefaultSendAs = 1 << 29,
            AvailableReactions = 1 << 30
        }

        [Flags]
        public enum Flags2Enum
        {
            CanDeleteChannel = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -362240487; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

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

        [Newtonsoft.Json.JsonIgnore] public int Flags2 { get; set; }

        [Newtonsoft.Json.JsonProperty("can_delete_channel")]
        public bool CanDeleteChannel { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("about")]
        public sealed override string About { get; set; }

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
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("exported_invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase ExportedInvite { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_info")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase> BotInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("migrated_from_chat_id")]
        public long? MigratedFromChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("migrated_from_max_id")]
        public int? MigratedFromMaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_msg_id")]
        public int? PinnedMsgId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Stickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("available_min_id")]
        public int? AvailableMinId { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public sealed override int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("linked_chat_id")]
        public long? LinkedChatId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("location")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase Location { get; set; }

        [Newtonsoft.Json.JsonProperty("slowmode_seconds")]
        public int? SlowmodeSeconds { get; set; }

        [Newtonsoft.Json.JsonProperty("slowmode_next_send_date")]
        public int? SlowmodeNextSendDate { get; set; }

        [Newtonsoft.Json.JsonProperty("stats_dc")]
        public int? StatsDc { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("call")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public int? TtlPeriod { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("pending_suggestions")]
        public List<string> PendingSuggestions { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("groupcall_default_join_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase GroupcallDefaultJoinAs { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("theme_emoticon")]
        public string ThemeEmoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("requests_pending")]
        public int? RequestsPending { get; set; }

        [Newtonsoft.Json.JsonProperty("recent_requesters")]
        public List<long> RecentRequesters { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("default_send_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase DefaultSendAs { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("available_reactions")]
        public List<string> AvailableReactions { get; set; }


#nullable enable
        public ChannelFull(long id, string about, int readInboxMaxId, int readOutboxMaxId, int unreadCount, CatraProto.Client.TL.Schemas.CloudChats.PhotoBase chatPhoto, CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase notifySettings, List<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase> botInfo, int pts)
        {
            Id = id;
            About = about;
            ReadInboxMaxId = readInboxMaxId;
            ReadOutboxMaxId = readOutboxMaxId;
            UnreadCount = unreadCount;
            ChatPhoto = chatPhoto;
            NotifySettings = notifySettings;
            BotInfo = botInfo;
            Pts = pts;
        }
#nullable disable
        internal ChannelFull()
        {
        }

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
            Flags2 = CanDeleteChannel ? FlagsHelper.SetFlag(Flags2, 0) : FlagsHelper.UnsetFlag(Flags2, 0);
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
            Flags = AvailableReactions == null ? FlagsHelper.UnsetFlag(Flags, 30) : FlagsHelper.SetFlag(Flags, 30);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            UpdateFlags();

            writer.WriteInt32(Flags2);
            writer.WriteInt64(Id);

            writer.WriteString(About);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(ParticipantsCount.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(AdminsCount.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(KickedCount.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(BannedCount.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                writer.WriteInt32(OnlineCount.Value);
            }

            writer.WriteInt32(ReadInboxMaxId);
            writer.WriteInt32(ReadOutboxMaxId);
            writer.WriteInt32(UnreadCount);
            var checkchatPhoto = writer.WriteObject(ChatPhoto);
            if (checkchatPhoto.IsError)
            {
                return checkchatPhoto;
            }

            var checknotifySettings = writer.WriteObject(NotifySettings);
            if (checknotifySettings.IsError)
            {
                return checknotifySettings;
            }

            if (FlagsHelper.IsFlagSet(Flags, 23))
            {
                var checkexportedInvite = writer.WriteObject(ExportedInvite);
                if (checkexportedInvite.IsError)
                {
                    return checkexportedInvite;
                }
            }

            var checkbotInfo = writer.WriteVector(BotInfo, false);
            if (checkbotInfo.IsError)
            {
                return checkbotInfo;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt64(MigratedFromChatId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(MigratedFromMaxId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteInt32(PinnedMsgId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                var checkstickerset = writer.WriteObject(Stickerset);
                if (checkstickerset.IsError)
                {
                    return checkstickerset;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                writer.WriteInt32(AvailableMinId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                writer.WriteInt32(FolderId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                writer.WriteInt64(LinkedChatId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 15))
            {
                var checklocation = writer.WriteObject(Location);
                if (checklocation.IsError)
                {
                    return checklocation;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                writer.WriteInt32(SlowmodeSeconds.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                writer.WriteInt32(SlowmodeNextSendDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                writer.WriteInt32(StatsDc.Value);
            }

            writer.WriteInt32(Pts);
            if (FlagsHelper.IsFlagSet(Flags, 21))
            {
                var checkcall = writer.WriteObject(Call);
                if (checkcall.IsError)
                {
                    return checkcall;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 24))
            {
                writer.WriteInt32(TtlPeriod.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                writer.WriteVector(PendingSuggestions, false);
            }

            if (FlagsHelper.IsFlagSet(Flags, 26))
            {
                var checkgroupcallDefaultJoinAs = writer.WriteObject(GroupcallDefaultJoinAs);
                if (checkgroupcallDefaultJoinAs.IsError)
                {
                    return checkgroupcallDefaultJoinAs;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 27))
            {
                writer.WriteString(ThemeEmoticon);
            }

            if (FlagsHelper.IsFlagSet(Flags, 28))
            {
                writer.WriteInt32(RequestsPending.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 28))
            {
                writer.WriteVector(RecentRequesters, false);
            }

            if (FlagsHelper.IsFlagSet(Flags, 29))
            {
                var checkdefaultSendAs = writer.WriteObject(DefaultSendAs);
                if (checkdefaultSendAs.IsError)
                {
                    return checkdefaultSendAs;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 30))
            {
                writer.WriteVector(AvailableReactions, false);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            CanViewParticipants = FlagsHelper.IsFlagSet(Flags, 3);
            CanSetUsername = FlagsHelper.IsFlagSet(Flags, 6);
            CanSetStickers = FlagsHelper.IsFlagSet(Flags, 7);
            HiddenPrehistory = FlagsHelper.IsFlagSet(Flags, 10);
            CanSetLocation = FlagsHelper.IsFlagSet(Flags, 16);
            HasScheduled = FlagsHelper.IsFlagSet(Flags, 19);
            CanViewStats = FlagsHelper.IsFlagSet(Flags, 20);
            Blocked = FlagsHelper.IsFlagSet(Flags, 22);
            var tryflags2 = reader.ReadInt32();
            if (tryflags2.IsError)
            {
                return ReadResult<IObject>.Move(tryflags2);
            }

            Flags2 = tryflags2.Value;
            CanDeleteChannel = FlagsHelper.IsFlagSet(Flags2, 0);
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryabout = reader.ReadString();
            if (tryabout.IsError)
            {
                return ReadResult<IObject>.Move(tryabout);
            }

            About = tryabout.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryparticipantsCount = reader.ReadInt32();
                if (tryparticipantsCount.IsError)
                {
                    return ReadResult<IObject>.Move(tryparticipantsCount);
                }

                ParticipantsCount = tryparticipantsCount.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryadminsCount = reader.ReadInt32();
                if (tryadminsCount.IsError)
                {
                    return ReadResult<IObject>.Move(tryadminsCount);
                }

                AdminsCount = tryadminsCount.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trykickedCount = reader.ReadInt32();
                if (trykickedCount.IsError)
                {
                    return ReadResult<IObject>.Move(trykickedCount);
                }

                KickedCount = trykickedCount.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trybannedCount = reader.ReadInt32();
                if (trybannedCount.IsError)
                {
                    return ReadResult<IObject>.Move(trybannedCount);
                }

                BannedCount = trybannedCount.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var tryonlineCount = reader.ReadInt32();
                if (tryonlineCount.IsError)
                {
                    return ReadResult<IObject>.Move(tryonlineCount);
                }

                OnlineCount = tryonlineCount.Value;
            }

            var tryreadInboxMaxId = reader.ReadInt32();
            if (tryreadInboxMaxId.IsError)
            {
                return ReadResult<IObject>.Move(tryreadInboxMaxId);
            }

            ReadInboxMaxId = tryreadInboxMaxId.Value;
            var tryreadOutboxMaxId = reader.ReadInt32();
            if (tryreadOutboxMaxId.IsError)
            {
                return ReadResult<IObject>.Move(tryreadOutboxMaxId);
            }

            ReadOutboxMaxId = tryreadOutboxMaxId.Value;
            var tryunreadCount = reader.ReadInt32();
            if (tryunreadCount.IsError)
            {
                return ReadResult<IObject>.Move(tryunreadCount);
            }

            UnreadCount = tryunreadCount.Value;
            var trychatPhoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            if (trychatPhoto.IsError)
            {
                return ReadResult<IObject>.Move(trychatPhoto);
            }

            ChatPhoto = trychatPhoto.Value;
            var trynotifySettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
            if (trynotifySettings.IsError)
            {
                return ReadResult<IObject>.Move(trynotifySettings);
            }

            NotifySettings = trynotifySettings.Value;
            if (FlagsHelper.IsFlagSet(Flags, 23))
            {
                var tryexportedInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
                if (tryexportedInvite.IsError)
                {
                    return ReadResult<IObject>.Move(tryexportedInvite);
                }

                ExportedInvite = tryexportedInvite.Value;
            }

            var trybotInfo = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trybotInfo.IsError)
            {
                return ReadResult<IObject>.Move(trybotInfo);
            }

            BotInfo = trybotInfo.Value;
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trymigratedFromChatId = reader.ReadInt64();
                if (trymigratedFromChatId.IsError)
                {
                    return ReadResult<IObject>.Move(trymigratedFromChatId);
                }

                MigratedFromChatId = trymigratedFromChatId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trymigratedFromMaxId = reader.ReadInt32();
                if (trymigratedFromMaxId.IsError)
                {
                    return ReadResult<IObject>.Move(trymigratedFromMaxId);
                }

                MigratedFromMaxId = trymigratedFromMaxId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var trypinnedMsgId = reader.ReadInt32();
                if (trypinnedMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trypinnedMsgId);
                }

                PinnedMsgId = trypinnedMsgId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
                if (trystickerset.IsError)
                {
                    return ReadResult<IObject>.Move(trystickerset);
                }

                Stickerset = trystickerset.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var tryavailableMinId = reader.ReadInt32();
                if (tryavailableMinId.IsError)
                {
                    return ReadResult<IObject>.Move(tryavailableMinId);
                }

                AvailableMinId = tryavailableMinId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                var tryfolderId = reader.ReadInt32();
                if (tryfolderId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfolderId);
                }

                FolderId = tryfolderId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                var trylinkedChatId = reader.ReadInt64();
                if (trylinkedChatId.IsError)
                {
                    return ReadResult<IObject>.Move(trylinkedChatId);
                }

                LinkedChatId = trylinkedChatId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 15))
            {
                var trylocation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();
                if (trylocation.IsError)
                {
                    return ReadResult<IObject>.Move(trylocation);
                }

                Location = trylocation.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                var tryslowmodeSeconds = reader.ReadInt32();
                if (tryslowmodeSeconds.IsError)
                {
                    return ReadResult<IObject>.Move(tryslowmodeSeconds);
                }

                SlowmodeSeconds = tryslowmodeSeconds.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                var tryslowmodeNextSendDate = reader.ReadInt32();
                if (tryslowmodeNextSendDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryslowmodeNextSendDate);
                }

                SlowmodeNextSendDate = tryslowmodeNextSendDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                var trystatsDc = reader.ReadInt32();
                if (trystatsDc.IsError)
                {
                    return ReadResult<IObject>.Move(trystatsDc);
                }

                StatsDc = trystatsDc.Value;
            }

            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }

            Pts = trypts.Value;
            if (FlagsHelper.IsFlagSet(Flags, 21))
            {
                var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
                if (trycall.IsError)
                {
                    return ReadResult<IObject>.Move(trycall);
                }

                Call = trycall.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 24))
            {
                var tryttlPeriod = reader.ReadInt32();
                if (tryttlPeriod.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlPeriod);
                }

                TtlPeriod = tryttlPeriod.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                var trypendingSuggestions = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
                if (trypendingSuggestions.IsError)
                {
                    return ReadResult<IObject>.Move(trypendingSuggestions);
                }

                PendingSuggestions = trypendingSuggestions.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 26))
            {
                var trygroupcallDefaultJoinAs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
                if (trygroupcallDefaultJoinAs.IsError)
                {
                    return ReadResult<IObject>.Move(trygroupcallDefaultJoinAs);
                }

                GroupcallDefaultJoinAs = trygroupcallDefaultJoinAs.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 27))
            {
                var trythemeEmoticon = reader.ReadString();
                if (trythemeEmoticon.IsError)
                {
                    return ReadResult<IObject>.Move(trythemeEmoticon);
                }

                ThemeEmoticon = trythemeEmoticon.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 28))
            {
                var tryrequestsPending = reader.ReadInt32();
                if (tryrequestsPending.IsError)
                {
                    return ReadResult<IObject>.Move(tryrequestsPending);
                }

                RequestsPending = tryrequestsPending.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 28))
            {
                var tryrecentRequesters = reader.ReadVector<long>(ParserTypes.Int64);
                if (tryrecentRequesters.IsError)
                {
                    return ReadResult<IObject>.Move(tryrecentRequesters);
                }

                RecentRequesters = tryrecentRequesters.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 29))
            {
                var trydefaultSendAs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
                if (trydefaultSendAs.IsError)
                {
                    return ReadResult<IObject>.Move(trydefaultSendAs);
                }

                DefaultSendAs = trydefaultSendAs.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 30))
            {
                var tryavailableReactions = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
                if (tryavailableReactions.IsError)
                {
                    return ReadResult<IObject>.Move(tryavailableReactions);
                }

                AvailableReactions = tryavailableReactions.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelFull";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelFull();
            newClonedObject.Flags = Flags;
            newClonedObject.CanViewParticipants = CanViewParticipants;
            newClonedObject.CanSetUsername = CanSetUsername;
            newClonedObject.CanSetStickers = CanSetStickers;
            newClonedObject.HiddenPrehistory = HiddenPrehistory;
            newClonedObject.CanSetLocation = CanSetLocation;
            newClonedObject.HasScheduled = HasScheduled;
            newClonedObject.CanViewStats = CanViewStats;
            newClonedObject.Blocked = Blocked;
            newClonedObject.Flags2 = Flags2;
            newClonedObject.CanDeleteChannel = CanDeleteChannel;
            newClonedObject.Id = Id;
            newClonedObject.About = About;
            newClonedObject.ParticipantsCount = ParticipantsCount;
            newClonedObject.AdminsCount = AdminsCount;
            newClonedObject.KickedCount = KickedCount;
            newClonedObject.BannedCount = BannedCount;
            newClonedObject.OnlineCount = OnlineCount;
            newClonedObject.ReadInboxMaxId = ReadInboxMaxId;
            newClonedObject.ReadOutboxMaxId = ReadOutboxMaxId;
            newClonedObject.UnreadCount = UnreadCount;
            var cloneChatPhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)ChatPhoto.Clone();
            if (cloneChatPhoto is null)
            {
                return null;
            }

            newClonedObject.ChatPhoto = cloneChatPhoto;
            var cloneNotifySettings = (CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase?)NotifySettings.Clone();
            if (cloneNotifySettings is null)
            {
                return null;
            }

            newClonedObject.NotifySettings = cloneNotifySettings;
            if (ExportedInvite is not null)
            {
                var cloneExportedInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)ExportedInvite.Clone();
                if (cloneExportedInvite is null)
                {
                    return null;
                }

                newClonedObject.ExportedInvite = cloneExportedInvite;
            }

            newClonedObject.BotInfo = new List<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>();
            foreach (var botInfo in BotInfo)
            {
                var clonebotInfo = (CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase?)botInfo.Clone();
                if (clonebotInfo is null)
                {
                    return null;
                }

                newClonedObject.BotInfo.Add(clonebotInfo);
            }

            newClonedObject.MigratedFromChatId = MigratedFromChatId;
            newClonedObject.MigratedFromMaxId = MigratedFromMaxId;
            newClonedObject.PinnedMsgId = PinnedMsgId;
            if (Stickerset is not null)
            {
                var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase?)Stickerset.Clone();
                if (cloneStickerset is null)
                {
                    return null;
                }

                newClonedObject.Stickerset = cloneStickerset;
            }

            newClonedObject.AvailableMinId = AvailableMinId;
            newClonedObject.FolderId = FolderId;
            newClonedObject.LinkedChatId = LinkedChatId;
            if (Location is not null)
            {
                var cloneLocation = (CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase?)Location.Clone();
                if (cloneLocation is null)
                {
                    return null;
                }

                newClonedObject.Location = cloneLocation;
            }

            newClonedObject.SlowmodeSeconds = SlowmodeSeconds;
            newClonedObject.SlowmodeNextSendDate = SlowmodeNextSendDate;
            newClonedObject.StatsDc = StatsDc;
            newClonedObject.Pts = Pts;
            if (Call is not null)
            {
                var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
                if (cloneCall is null)
                {
                    return null;
                }

                newClonedObject.Call = cloneCall;
            }

            newClonedObject.TtlPeriod = TtlPeriod;
            if (PendingSuggestions is not null)
            {
                newClonedObject.PendingSuggestions = new List<string>();
                foreach (var pendingSuggestions in PendingSuggestions)
                {
                    newClonedObject.PendingSuggestions.Add(pendingSuggestions);
                }
            }

            if (GroupcallDefaultJoinAs is not null)
            {
                var cloneGroupcallDefaultJoinAs = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)GroupcallDefaultJoinAs.Clone();
                if (cloneGroupcallDefaultJoinAs is null)
                {
                    return null;
                }

                newClonedObject.GroupcallDefaultJoinAs = cloneGroupcallDefaultJoinAs;
            }

            newClonedObject.ThemeEmoticon = ThemeEmoticon;
            newClonedObject.RequestsPending = RequestsPending;
            if (RecentRequesters is not null)
            {
                newClonedObject.RecentRequesters = new List<long>();
                foreach (var recentRequesters in RecentRequesters)
                {
                    newClonedObject.RecentRequesters.Add(recentRequesters);
                }
            }

            if (DefaultSendAs is not null)
            {
                var cloneDefaultSendAs = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)DefaultSendAs.Clone();
                if (cloneDefaultSendAs is null)
                {
                    return null;
                }

                newClonedObject.DefaultSendAs = cloneDefaultSendAs;
            }

            if (AvailableReactions is not null)
            {
                newClonedObject.AvailableReactions = new List<string>();
                foreach (var availableReactions in AvailableReactions)
                {
                    newClonedObject.AvailableReactions.Add(availableReactions);
                }
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelFull castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (CanViewParticipants != castedOther.CanViewParticipants)
            {
                return true;
            }

            if (CanSetUsername != castedOther.CanSetUsername)
            {
                return true;
            }

            if (CanSetStickers != castedOther.CanSetStickers)
            {
                return true;
            }

            if (HiddenPrehistory != castedOther.HiddenPrehistory)
            {
                return true;
            }

            if (CanSetLocation != castedOther.CanSetLocation)
            {
                return true;
            }

            if (HasScheduled != castedOther.HasScheduled)
            {
                return true;
            }

            if (CanViewStats != castedOther.CanViewStats)
            {
                return true;
            }

            if (Blocked != castedOther.Blocked)
            {
                return true;
            }

            if (Flags2 != castedOther.Flags2)
            {
                return true;
            }

            if (CanDeleteChannel != castedOther.CanDeleteChannel)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (About != castedOther.About)
            {
                return true;
            }

            if (ParticipantsCount != castedOther.ParticipantsCount)
            {
                return true;
            }

            if (AdminsCount != castedOther.AdminsCount)
            {
                return true;
            }

            if (KickedCount != castedOther.KickedCount)
            {
                return true;
            }

            if (BannedCount != castedOther.BannedCount)
            {
                return true;
            }

            if (OnlineCount != castedOther.OnlineCount)
            {
                return true;
            }

            if (ReadInboxMaxId != castedOther.ReadInboxMaxId)
            {
                return true;
            }

            if (ReadOutboxMaxId != castedOther.ReadOutboxMaxId)
            {
                return true;
            }

            if (UnreadCount != castedOther.UnreadCount)
            {
                return true;
            }

            if (ChatPhoto.Compare(castedOther.ChatPhoto))
            {
                return true;
            }

            if (NotifySettings.Compare(castedOther.NotifySettings))
            {
                return true;
            }

            if (ExportedInvite is null && castedOther.ExportedInvite is not null || ExportedInvite is not null && castedOther.ExportedInvite is null)
            {
                return true;
            }

            if (ExportedInvite is not null && castedOther.ExportedInvite is not null && ExportedInvite.Compare(castedOther.ExportedInvite))
            {
                return true;
            }

            var botInfosize = castedOther.BotInfo.Count;
            if (botInfosize != BotInfo.Count)
            {
                return true;
            }

            for (var i = 0; i < botInfosize; i++)
            {
                if (castedOther.BotInfo[i].Compare(BotInfo[i]))
                {
                    return true;
                }
            }

            if (MigratedFromChatId != castedOther.MigratedFromChatId)
            {
                return true;
            }

            if (MigratedFromMaxId != castedOther.MigratedFromMaxId)
            {
                return true;
            }

            if (PinnedMsgId != castedOther.PinnedMsgId)
            {
                return true;
            }

            if (Stickerset is null && castedOther.Stickerset is not null || Stickerset is not null && castedOther.Stickerset is null)
            {
                return true;
            }

            if (Stickerset is not null && castedOther.Stickerset is not null && Stickerset.Compare(castedOther.Stickerset))
            {
                return true;
            }

            if (AvailableMinId != castedOther.AvailableMinId)
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
            {
                return true;
            }

            if (LinkedChatId != castedOther.LinkedChatId)
            {
                return true;
            }

            if (Location is null && castedOther.Location is not null || Location is not null && castedOther.Location is null)
            {
                return true;
            }

            if (Location is not null && castedOther.Location is not null && Location.Compare(castedOther.Location))
            {
                return true;
            }

            if (SlowmodeSeconds != castedOther.SlowmodeSeconds)
            {
                return true;
            }

            if (SlowmodeNextSendDate != castedOther.SlowmodeNextSendDate)
            {
                return true;
            }

            if (StatsDc != castedOther.StatsDc)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (Call is null && castedOther.Call is not null || Call is not null && castedOther.Call is null)
            {
                return true;
            }

            if (Call is not null && castedOther.Call is not null && Call.Compare(castedOther.Call))
            {
                return true;
            }

            if (TtlPeriod != castedOther.TtlPeriod)
            {
                return true;
            }

            if (PendingSuggestions is null && castedOther.PendingSuggestions is not null || PendingSuggestions is not null && castedOther.PendingSuggestions is null)
            {
                return true;
            }

            if (PendingSuggestions is not null && castedOther.PendingSuggestions is not null)
            {
                var pendingSuggestionssize = castedOther.PendingSuggestions.Count;
                if (pendingSuggestionssize != PendingSuggestions.Count)
                {
                    return true;
                }

                for (var i = 0; i < pendingSuggestionssize; i++)
                {
                    if (castedOther.PendingSuggestions[i] != PendingSuggestions[i])
                    {
                        return true;
                    }
                }
            }

            if (GroupcallDefaultJoinAs is null && castedOther.GroupcallDefaultJoinAs is not null || GroupcallDefaultJoinAs is not null && castedOther.GroupcallDefaultJoinAs is null)
            {
                return true;
            }

            if (GroupcallDefaultJoinAs is not null && castedOther.GroupcallDefaultJoinAs is not null && GroupcallDefaultJoinAs.Compare(castedOther.GroupcallDefaultJoinAs))
            {
                return true;
            }

            if (ThemeEmoticon != castedOther.ThemeEmoticon)
            {
                return true;
            }

            if (RequestsPending != castedOther.RequestsPending)
            {
                return true;
            }

            if (RecentRequesters is null && castedOther.RecentRequesters is not null || RecentRequesters is not null && castedOther.RecentRequesters is null)
            {
                return true;
            }

            if (RecentRequesters is not null && castedOther.RecentRequesters is not null)
            {
                var recentRequesterssize = castedOther.RecentRequesters.Count;
                if (recentRequesterssize != RecentRequesters.Count)
                {
                    return true;
                }

                for (var i = 0; i < recentRequesterssize; i++)
                {
                    if (castedOther.RecentRequesters[i] != RecentRequesters[i])
                    {
                        return true;
                    }
                }
            }

            if (DefaultSendAs is null && castedOther.DefaultSendAs is not null || DefaultSendAs is not null && castedOther.DefaultSendAs is null)
            {
                return true;
            }

            if (DefaultSendAs is not null && castedOther.DefaultSendAs is not null && DefaultSendAs.Compare(castedOther.DefaultSendAs))
            {
                return true;
            }

            if (AvailableReactions is null && castedOther.AvailableReactions is not null || AvailableReactions is not null && castedOther.AvailableReactions is null)
            {
                return true;
            }

            if (AvailableReactions is not null && castedOther.AvailableReactions is not null)
            {
                var availableReactionssize = castedOther.AvailableReactions.Count;
                if (availableReactionssize != AvailableReactions.Count)
                {
                    return true;
                }

                for (var i = 0; i < availableReactionssize; i++)
                {
                    if (castedOther.AvailableReactions[i] != AvailableReactions[i])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

#nullable disable
    }
}