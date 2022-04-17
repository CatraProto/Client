using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -516145888; }

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
        public sealed override long Id { get; set; }

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

        [Newtonsoft.Json.JsonProperty("pts")]
        public int Pts { get; set; }

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
    }
}