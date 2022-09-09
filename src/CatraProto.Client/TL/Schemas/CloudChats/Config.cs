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
    public partial class Config : CatraProto.Client.TL.Schemas.CloudChats.ConfigBase
    {
        [Flags]
        public enum FlagsEnum
        {
            PhonecallsEnabled = 1 << 1,
            DefaultP2pContacts = 1 << 3,
            PreloadFeaturedStickers = 1 << 4,
            IgnorePhoneEntities = 1 << 5,
            RevokePmInbox = 1 << 6,
            BlockedMode = 1 << 8,
            PfsEnabled = 1 << 13,
            ForceTryIpv6 = 1 << 14,
            TmpSessions = 1 << 0,
            AutoupdateUrlPrefix = 1 << 7,
            GifSearchUsername = 1 << 9,
            VenueSearchUsername = 1 << 10,
            ImgSearchUsername = 1 << 11,
            StaticMapsProvider = 1 << 12,
            SuggestedLangCode = 1 << 2,
            LangPackVersion = 1 << 2,
            BaseLangPackVersion = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 856375399; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("phonecalls_enabled")]
        public sealed override bool PhonecallsEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("default_p2p_contacts")]
        public sealed override bool DefaultP2pContacts { get; set; }

        [Newtonsoft.Json.JsonProperty("preload_featured_stickers")]
        public sealed override bool PreloadFeaturedStickers { get; set; }

        [Newtonsoft.Json.JsonProperty("ignore_phone_entities")]
        public sealed override bool IgnorePhoneEntities { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke_pm_inbox")]
        public sealed override bool RevokePmInbox { get; set; }

        [Newtonsoft.Json.JsonProperty("blocked_mode")]
        public sealed override bool BlockedMode { get; set; }

        [Newtonsoft.Json.JsonProperty("pfs_enabled")]
        public sealed override bool PfsEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("force_try_ipv6")]
        public sealed override bool ForceTryIpv6 { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public sealed override int Expires { get; set; }

        [Newtonsoft.Json.JsonProperty("test_mode")]
        public sealed override bool TestMode { get; set; }

        [Newtonsoft.Json.JsonProperty("this_dc")]
        public sealed override int ThisDc { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_options")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> DcOptions { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_txt_domain_name")]
        public sealed override string DcTxtDomainName { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_size_max")]
        public sealed override int ChatSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("megagroup_size_max")]
        public sealed override int MegagroupSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("forwarded_count_max")]
        public sealed override int ForwardedCountMax { get; set; }

        [Newtonsoft.Json.JsonProperty("online_update_period_ms")]
        public sealed override int OnlineUpdatePeriodMs { get; set; }

        [Newtonsoft.Json.JsonProperty("offline_blur_timeout_ms")]
        public sealed override int OfflineBlurTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("offline_idle_timeout_ms")]
        public sealed override int OfflineIdleTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("online_cloud_timeout_ms")]
        public sealed override int OnlineCloudTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_cloud_delay_ms")]
        public sealed override int NotifyCloudDelayMs { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_default_delay_ms")]
        public sealed override int NotifyDefaultDelayMs { get; set; }

        [Newtonsoft.Json.JsonProperty("push_chat_period_ms")]
        public sealed override int PushChatPeriodMs { get; set; }

        [Newtonsoft.Json.JsonProperty("push_chat_limit")]
        public sealed override int PushChatLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("saved_gifs_limit")]
        public sealed override int SavedGifsLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("edit_time_limit")]
        public sealed override int EditTimeLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke_time_limit")]
        public sealed override int RevokeTimeLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke_pm_time_limit")]
        public sealed override int RevokePmTimeLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("rating_e_decay")]
        public sealed override int RatingEDecay { get; set; }

        [Newtonsoft.Json.JsonProperty("stickers_recent_limit")]
        public sealed override int StickersRecentLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("stickers_faved_limit")]
        public sealed override int StickersFavedLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("channels_read_media_period")]
        public sealed override int ChannelsReadMediaPeriod { get; set; }

        [Newtonsoft.Json.JsonProperty("tmp_sessions")]
        public sealed override int? TmpSessions { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_dialogs_count_max")]
        public sealed override int PinnedDialogsCountMax { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_infolder_count_max")]
        public sealed override int PinnedInfolderCountMax { get; set; }

        [Newtonsoft.Json.JsonProperty("call_receive_timeout_ms")]
        public sealed override int CallReceiveTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("call_ring_timeout_ms")]
        public sealed override int CallRingTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("call_connect_timeout_ms")]
        public sealed override int CallConnectTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("call_packet_timeout_ms")]
        public sealed override int CallPacketTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("me_url_prefix")]
        public sealed override string MeUrlPrefix { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("autoupdate_url_prefix")]
        public sealed override string AutoupdateUrlPrefix { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("gif_search_username")]
        public sealed override string GifSearchUsername { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("venue_search_username")]
        public sealed override string VenueSearchUsername { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("img_search_username")]
        public sealed override string ImgSearchUsername { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("static_maps_provider")]
        public sealed override string StaticMapsProvider { get; set; }

        [Newtonsoft.Json.JsonProperty("caption_length_max")]
        public sealed override int CaptionLengthMax { get; set; }

        [Newtonsoft.Json.JsonProperty("message_length_max")]
        public sealed override int MessageLengthMax { get; set; }

        [Newtonsoft.Json.JsonProperty("webfile_dc_id")]
        public sealed override int WebfileDcId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("suggested_lang_code")]
        public sealed override string SuggestedLangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_pack_version")]
        public sealed override int? LangPackVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("base_lang_pack_version")]
        public sealed override int? BaseLangPackVersion { get; set; }


#nullable enable
        public Config(int date, int expires, bool testMode, int thisDc, List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> dcOptions, string dcTxtDomainName, int chatSizeMax, int megagroupSizeMax, int forwardedCountMax, int onlineUpdatePeriodMs, int offlineBlurTimeoutMs, int offlineIdleTimeoutMs, int onlineCloudTimeoutMs, int notifyCloudDelayMs, int notifyDefaultDelayMs, int pushChatPeriodMs, int pushChatLimit, int savedGifsLimit, int editTimeLimit, int revokeTimeLimit, int revokePmTimeLimit, int ratingEDecay, int stickersRecentLimit, int stickersFavedLimit, int channelsReadMediaPeriod, int pinnedDialogsCountMax, int pinnedInfolderCountMax, int callReceiveTimeoutMs, int callRingTimeoutMs, int callConnectTimeoutMs, int callPacketTimeoutMs, string meUrlPrefix, int captionLengthMax, int messageLengthMax, int webfileDcId)
        {
            Date = date;
            Expires = expires;
            TestMode = testMode;
            ThisDc = thisDc;
            DcOptions = dcOptions;
            DcTxtDomainName = dcTxtDomainName;
            ChatSizeMax = chatSizeMax;
            MegagroupSizeMax = megagroupSizeMax;
            ForwardedCountMax = forwardedCountMax;
            OnlineUpdatePeriodMs = onlineUpdatePeriodMs;
            OfflineBlurTimeoutMs = offlineBlurTimeoutMs;
            OfflineIdleTimeoutMs = offlineIdleTimeoutMs;
            OnlineCloudTimeoutMs = onlineCloudTimeoutMs;
            NotifyCloudDelayMs = notifyCloudDelayMs;
            NotifyDefaultDelayMs = notifyDefaultDelayMs;
            PushChatPeriodMs = pushChatPeriodMs;
            PushChatLimit = pushChatLimit;
            SavedGifsLimit = savedGifsLimit;
            EditTimeLimit = editTimeLimit;
            RevokeTimeLimit = revokeTimeLimit;
            RevokePmTimeLimit = revokePmTimeLimit;
            RatingEDecay = ratingEDecay;
            StickersRecentLimit = stickersRecentLimit;
            StickersFavedLimit = stickersFavedLimit;
            ChannelsReadMediaPeriod = channelsReadMediaPeriod;
            PinnedDialogsCountMax = pinnedDialogsCountMax;
            PinnedInfolderCountMax = pinnedInfolderCountMax;
            CallReceiveTimeoutMs = callReceiveTimeoutMs;
            CallRingTimeoutMs = callRingTimeoutMs;
            CallConnectTimeoutMs = callConnectTimeoutMs;
            CallPacketTimeoutMs = callPacketTimeoutMs;
            MeUrlPrefix = meUrlPrefix;
            CaptionLengthMax = captionLengthMax;
            MessageLengthMax = messageLengthMax;
            WebfileDcId = webfileDcId;
        }
#nullable disable
        internal Config()
        {
        }

        public override void UpdateFlags()
        {
            Flags = PhonecallsEnabled ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = DefaultP2pContacts ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = PreloadFeaturedStickers ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = IgnorePhoneEntities ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = RevokePmInbox ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = BlockedMode ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = PfsEnabled ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
            Flags = ForceTryIpv6 ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
            Flags = TmpSessions == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = AutoupdateUrlPrefix == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = GifSearchUsername == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
            Flags = VenueSearchUsername == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
            Flags = ImgSearchUsername == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
            Flags = StaticMapsProvider == null ? FlagsHelper.UnsetFlag(Flags, 12) : FlagsHelper.SetFlag(Flags, 12);
            Flags = SuggestedLangCode == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = LangPackVersion == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = BaseLangPackVersion == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Date);
            writer.WriteInt32(Expires);
            var checktestMode = writer.WriteBool(TestMode);
            if (checktestMode.IsError)
            {
                return checktestMode;
            }

            writer.WriteInt32(ThisDc);
            var checkdcOptions = writer.WriteVector(DcOptions, false);
            if (checkdcOptions.IsError)
            {
                return checkdcOptions;
            }

            writer.WriteString(DcTxtDomainName);
            writer.WriteInt32(ChatSizeMax);
            writer.WriteInt32(MegagroupSizeMax);
            writer.WriteInt32(ForwardedCountMax);
            writer.WriteInt32(OnlineUpdatePeriodMs);
            writer.WriteInt32(OfflineBlurTimeoutMs);
            writer.WriteInt32(OfflineIdleTimeoutMs);
            writer.WriteInt32(OnlineCloudTimeoutMs);
            writer.WriteInt32(NotifyCloudDelayMs);
            writer.WriteInt32(NotifyDefaultDelayMs);
            writer.WriteInt32(PushChatPeriodMs);
            writer.WriteInt32(PushChatLimit);
            writer.WriteInt32(SavedGifsLimit);
            writer.WriteInt32(EditTimeLimit);
            writer.WriteInt32(RevokeTimeLimit);
            writer.WriteInt32(RevokePmTimeLimit);
            writer.WriteInt32(RatingEDecay);
            writer.WriteInt32(StickersRecentLimit);
            writer.WriteInt32(StickersFavedLimit);
            writer.WriteInt32(ChannelsReadMediaPeriod);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(TmpSessions.Value);
            }

            writer.WriteInt32(PinnedDialogsCountMax);
            writer.WriteInt32(PinnedInfolderCountMax);
            writer.WriteInt32(CallReceiveTimeoutMs);
            writer.WriteInt32(CallRingTimeoutMs);
            writer.WriteInt32(CallConnectTimeoutMs);
            writer.WriteInt32(CallPacketTimeoutMs);

            writer.WriteString(MeUrlPrefix);
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.WriteString(AutoupdateUrlPrefix);
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                writer.WriteString(GifSearchUsername);
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                writer.WriteString(VenueSearchUsername);
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                writer.WriteString(ImgSearchUsername);
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                writer.WriteString(StaticMapsProvider);
            }

            writer.WriteInt32(CaptionLengthMax);
            writer.WriteInt32(MessageLengthMax);
            writer.WriteInt32(WebfileDcId);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(SuggestedLangCode);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(LangPackVersion.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(BaseLangPackVersion.Value);
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
            PhonecallsEnabled = FlagsHelper.IsFlagSet(Flags, 1);
            DefaultP2pContacts = FlagsHelper.IsFlagSet(Flags, 3);
            PreloadFeaturedStickers = FlagsHelper.IsFlagSet(Flags, 4);
            IgnorePhoneEntities = FlagsHelper.IsFlagSet(Flags, 5);
            RevokePmInbox = FlagsHelper.IsFlagSet(Flags, 6);
            BlockedMode = FlagsHelper.IsFlagSet(Flags, 8);
            PfsEnabled = FlagsHelper.IsFlagSet(Flags, 13);
            ForceTryIpv6 = FlagsHelper.IsFlagSet(Flags, 14);
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }

            Expires = tryexpires.Value;
            var trytestMode = reader.ReadBool();
            if (trytestMode.IsError)
            {
                return ReadResult<IObject>.Move(trytestMode);
            }

            TestMode = trytestMode.Value;
            var trythisDc = reader.ReadInt32();
            if (trythisDc.IsError)
            {
                return ReadResult<IObject>.Move(trythisDc);
            }

            ThisDc = trythisDc.Value;
            var trydcOptions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trydcOptions.IsError)
            {
                return ReadResult<IObject>.Move(trydcOptions);
            }

            DcOptions = trydcOptions.Value;
            var trydcTxtDomainName = reader.ReadString();
            if (trydcTxtDomainName.IsError)
            {
                return ReadResult<IObject>.Move(trydcTxtDomainName);
            }

            DcTxtDomainName = trydcTxtDomainName.Value;
            var trychatSizeMax = reader.ReadInt32();
            if (trychatSizeMax.IsError)
            {
                return ReadResult<IObject>.Move(trychatSizeMax);
            }

            ChatSizeMax = trychatSizeMax.Value;
            var trymegagroupSizeMax = reader.ReadInt32();
            if (trymegagroupSizeMax.IsError)
            {
                return ReadResult<IObject>.Move(trymegagroupSizeMax);
            }

            MegagroupSizeMax = trymegagroupSizeMax.Value;
            var tryforwardedCountMax = reader.ReadInt32();
            if (tryforwardedCountMax.IsError)
            {
                return ReadResult<IObject>.Move(tryforwardedCountMax);
            }

            ForwardedCountMax = tryforwardedCountMax.Value;
            var tryonlineUpdatePeriodMs = reader.ReadInt32();
            if (tryonlineUpdatePeriodMs.IsError)
            {
                return ReadResult<IObject>.Move(tryonlineUpdatePeriodMs);
            }

            OnlineUpdatePeriodMs = tryonlineUpdatePeriodMs.Value;
            var tryofflineBlurTimeoutMs = reader.ReadInt32();
            if (tryofflineBlurTimeoutMs.IsError)
            {
                return ReadResult<IObject>.Move(tryofflineBlurTimeoutMs);
            }

            OfflineBlurTimeoutMs = tryofflineBlurTimeoutMs.Value;
            var tryofflineIdleTimeoutMs = reader.ReadInt32();
            if (tryofflineIdleTimeoutMs.IsError)
            {
                return ReadResult<IObject>.Move(tryofflineIdleTimeoutMs);
            }

            OfflineIdleTimeoutMs = tryofflineIdleTimeoutMs.Value;
            var tryonlineCloudTimeoutMs = reader.ReadInt32();
            if (tryonlineCloudTimeoutMs.IsError)
            {
                return ReadResult<IObject>.Move(tryonlineCloudTimeoutMs);
            }

            OnlineCloudTimeoutMs = tryonlineCloudTimeoutMs.Value;
            var trynotifyCloudDelayMs = reader.ReadInt32();
            if (trynotifyCloudDelayMs.IsError)
            {
                return ReadResult<IObject>.Move(trynotifyCloudDelayMs);
            }

            NotifyCloudDelayMs = trynotifyCloudDelayMs.Value;
            var trynotifyDefaultDelayMs = reader.ReadInt32();
            if (trynotifyDefaultDelayMs.IsError)
            {
                return ReadResult<IObject>.Move(trynotifyDefaultDelayMs);
            }

            NotifyDefaultDelayMs = trynotifyDefaultDelayMs.Value;
            var trypushChatPeriodMs = reader.ReadInt32();
            if (trypushChatPeriodMs.IsError)
            {
                return ReadResult<IObject>.Move(trypushChatPeriodMs);
            }

            PushChatPeriodMs = trypushChatPeriodMs.Value;
            var trypushChatLimit = reader.ReadInt32();
            if (trypushChatLimit.IsError)
            {
                return ReadResult<IObject>.Move(trypushChatLimit);
            }

            PushChatLimit = trypushChatLimit.Value;
            var trysavedGifsLimit = reader.ReadInt32();
            if (trysavedGifsLimit.IsError)
            {
                return ReadResult<IObject>.Move(trysavedGifsLimit);
            }

            SavedGifsLimit = trysavedGifsLimit.Value;
            var tryeditTimeLimit = reader.ReadInt32();
            if (tryeditTimeLimit.IsError)
            {
                return ReadResult<IObject>.Move(tryeditTimeLimit);
            }

            EditTimeLimit = tryeditTimeLimit.Value;
            var tryrevokeTimeLimit = reader.ReadInt32();
            if (tryrevokeTimeLimit.IsError)
            {
                return ReadResult<IObject>.Move(tryrevokeTimeLimit);
            }

            RevokeTimeLimit = tryrevokeTimeLimit.Value;
            var tryrevokePmTimeLimit = reader.ReadInt32();
            if (tryrevokePmTimeLimit.IsError)
            {
                return ReadResult<IObject>.Move(tryrevokePmTimeLimit);
            }

            RevokePmTimeLimit = tryrevokePmTimeLimit.Value;
            var tryratingEDecay = reader.ReadInt32();
            if (tryratingEDecay.IsError)
            {
                return ReadResult<IObject>.Move(tryratingEDecay);
            }

            RatingEDecay = tryratingEDecay.Value;
            var trystickersRecentLimit = reader.ReadInt32();
            if (trystickersRecentLimit.IsError)
            {
                return ReadResult<IObject>.Move(trystickersRecentLimit);
            }

            StickersRecentLimit = trystickersRecentLimit.Value;
            var trystickersFavedLimit = reader.ReadInt32();
            if (trystickersFavedLimit.IsError)
            {
                return ReadResult<IObject>.Move(trystickersFavedLimit);
            }

            StickersFavedLimit = trystickersFavedLimit.Value;
            var trychannelsReadMediaPeriod = reader.ReadInt32();
            if (trychannelsReadMediaPeriod.IsError)
            {
                return ReadResult<IObject>.Move(trychannelsReadMediaPeriod);
            }

            ChannelsReadMediaPeriod = trychannelsReadMediaPeriod.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trytmpSessions = reader.ReadInt32();
                if (trytmpSessions.IsError)
                {
                    return ReadResult<IObject>.Move(trytmpSessions);
                }

                TmpSessions = trytmpSessions.Value;
            }

            var trypinnedDialogsCountMax = reader.ReadInt32();
            if (trypinnedDialogsCountMax.IsError)
            {
                return ReadResult<IObject>.Move(trypinnedDialogsCountMax);
            }

            PinnedDialogsCountMax = trypinnedDialogsCountMax.Value;
            var trypinnedInfolderCountMax = reader.ReadInt32();
            if (trypinnedInfolderCountMax.IsError)
            {
                return ReadResult<IObject>.Move(trypinnedInfolderCountMax);
            }

            PinnedInfolderCountMax = trypinnedInfolderCountMax.Value;
            var trycallReceiveTimeoutMs = reader.ReadInt32();
            if (trycallReceiveTimeoutMs.IsError)
            {
                return ReadResult<IObject>.Move(trycallReceiveTimeoutMs);
            }

            CallReceiveTimeoutMs = trycallReceiveTimeoutMs.Value;
            var trycallRingTimeoutMs = reader.ReadInt32();
            if (trycallRingTimeoutMs.IsError)
            {
                return ReadResult<IObject>.Move(trycallRingTimeoutMs);
            }

            CallRingTimeoutMs = trycallRingTimeoutMs.Value;
            var trycallConnectTimeoutMs = reader.ReadInt32();
            if (trycallConnectTimeoutMs.IsError)
            {
                return ReadResult<IObject>.Move(trycallConnectTimeoutMs);
            }

            CallConnectTimeoutMs = trycallConnectTimeoutMs.Value;
            var trycallPacketTimeoutMs = reader.ReadInt32();
            if (trycallPacketTimeoutMs.IsError)
            {
                return ReadResult<IObject>.Move(trycallPacketTimeoutMs);
            }

            CallPacketTimeoutMs = trycallPacketTimeoutMs.Value;
            var trymeUrlPrefix = reader.ReadString();
            if (trymeUrlPrefix.IsError)
            {
                return ReadResult<IObject>.Move(trymeUrlPrefix);
            }

            MeUrlPrefix = trymeUrlPrefix.Value;
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var tryautoupdateUrlPrefix = reader.ReadString();
                if (tryautoupdateUrlPrefix.IsError)
                {
                    return ReadResult<IObject>.Move(tryautoupdateUrlPrefix);
                }

                AutoupdateUrlPrefix = tryautoupdateUrlPrefix.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var trygifSearchUsername = reader.ReadString();
                if (trygifSearchUsername.IsError)
                {
                    return ReadResult<IObject>.Move(trygifSearchUsername);
                }

                GifSearchUsername = trygifSearchUsername.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                var tryvenueSearchUsername = reader.ReadString();
                if (tryvenueSearchUsername.IsError)
                {
                    return ReadResult<IObject>.Move(tryvenueSearchUsername);
                }

                VenueSearchUsername = tryvenueSearchUsername.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                var tryimgSearchUsername = reader.ReadString();
                if (tryimgSearchUsername.IsError)
                {
                    return ReadResult<IObject>.Move(tryimgSearchUsername);
                }

                ImgSearchUsername = tryimgSearchUsername.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                var trystaticMapsProvider = reader.ReadString();
                if (trystaticMapsProvider.IsError)
                {
                    return ReadResult<IObject>.Move(trystaticMapsProvider);
                }

                StaticMapsProvider = trystaticMapsProvider.Value;
            }

            var trycaptionLengthMax = reader.ReadInt32();
            if (trycaptionLengthMax.IsError)
            {
                return ReadResult<IObject>.Move(trycaptionLengthMax);
            }

            CaptionLengthMax = trycaptionLengthMax.Value;
            var trymessageLengthMax = reader.ReadInt32();
            if (trymessageLengthMax.IsError)
            {
                return ReadResult<IObject>.Move(trymessageLengthMax);
            }

            MessageLengthMax = trymessageLengthMax.Value;
            var trywebfileDcId = reader.ReadInt32();
            if (trywebfileDcId.IsError)
            {
                return ReadResult<IObject>.Move(trywebfileDcId);
            }

            WebfileDcId = trywebfileDcId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trysuggestedLangCode = reader.ReadString();
                if (trysuggestedLangCode.IsError)
                {
                    return ReadResult<IObject>.Move(trysuggestedLangCode);
                }

                SuggestedLangCode = trysuggestedLangCode.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trylangPackVersion = reader.ReadInt32();
                if (trylangPackVersion.IsError)
                {
                    return ReadResult<IObject>.Move(trylangPackVersion);
                }

                LangPackVersion = trylangPackVersion.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trybaseLangPackVersion = reader.ReadInt32();
                if (trybaseLangPackVersion.IsError)
                {
                    return ReadResult<IObject>.Move(trybaseLangPackVersion);
                }

                BaseLangPackVersion = trybaseLangPackVersion.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "config";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Config();
            newClonedObject.Flags = Flags;
            newClonedObject.PhonecallsEnabled = PhonecallsEnabled;
            newClonedObject.DefaultP2pContacts = DefaultP2pContacts;
            newClonedObject.PreloadFeaturedStickers = PreloadFeaturedStickers;
            newClonedObject.IgnorePhoneEntities = IgnorePhoneEntities;
            newClonedObject.RevokePmInbox = RevokePmInbox;
            newClonedObject.BlockedMode = BlockedMode;
            newClonedObject.PfsEnabled = PfsEnabled;
            newClonedObject.ForceTryIpv6 = ForceTryIpv6;
            newClonedObject.Date = Date;
            newClonedObject.Expires = Expires;
            newClonedObject.TestMode = TestMode;
            newClonedObject.ThisDc = ThisDc;
            newClonedObject.DcOptions = new List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase>();
            foreach (var dcOptions in DcOptions)
            {
                var clonedcOptions = (CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase?)dcOptions.Clone();
                if (clonedcOptions is null)
                {
                    return null;
                }

                newClonedObject.DcOptions.Add(clonedcOptions);
            }

            newClonedObject.DcTxtDomainName = DcTxtDomainName;
            newClonedObject.ChatSizeMax = ChatSizeMax;
            newClonedObject.MegagroupSizeMax = MegagroupSizeMax;
            newClonedObject.ForwardedCountMax = ForwardedCountMax;
            newClonedObject.OnlineUpdatePeriodMs = OnlineUpdatePeriodMs;
            newClonedObject.OfflineBlurTimeoutMs = OfflineBlurTimeoutMs;
            newClonedObject.OfflineIdleTimeoutMs = OfflineIdleTimeoutMs;
            newClonedObject.OnlineCloudTimeoutMs = OnlineCloudTimeoutMs;
            newClonedObject.NotifyCloudDelayMs = NotifyCloudDelayMs;
            newClonedObject.NotifyDefaultDelayMs = NotifyDefaultDelayMs;
            newClonedObject.PushChatPeriodMs = PushChatPeriodMs;
            newClonedObject.PushChatLimit = PushChatLimit;
            newClonedObject.SavedGifsLimit = SavedGifsLimit;
            newClonedObject.EditTimeLimit = EditTimeLimit;
            newClonedObject.RevokeTimeLimit = RevokeTimeLimit;
            newClonedObject.RevokePmTimeLimit = RevokePmTimeLimit;
            newClonedObject.RatingEDecay = RatingEDecay;
            newClonedObject.StickersRecentLimit = StickersRecentLimit;
            newClonedObject.StickersFavedLimit = StickersFavedLimit;
            newClonedObject.ChannelsReadMediaPeriod = ChannelsReadMediaPeriod;
            newClonedObject.TmpSessions = TmpSessions;
            newClonedObject.PinnedDialogsCountMax = PinnedDialogsCountMax;
            newClonedObject.PinnedInfolderCountMax = PinnedInfolderCountMax;
            newClonedObject.CallReceiveTimeoutMs = CallReceiveTimeoutMs;
            newClonedObject.CallRingTimeoutMs = CallRingTimeoutMs;
            newClonedObject.CallConnectTimeoutMs = CallConnectTimeoutMs;
            newClonedObject.CallPacketTimeoutMs = CallPacketTimeoutMs;
            newClonedObject.MeUrlPrefix = MeUrlPrefix;
            newClonedObject.AutoupdateUrlPrefix = AutoupdateUrlPrefix;
            newClonedObject.GifSearchUsername = GifSearchUsername;
            newClonedObject.VenueSearchUsername = VenueSearchUsername;
            newClonedObject.ImgSearchUsername = ImgSearchUsername;
            newClonedObject.StaticMapsProvider = StaticMapsProvider;
            newClonedObject.CaptionLengthMax = CaptionLengthMax;
            newClonedObject.MessageLengthMax = MessageLengthMax;
            newClonedObject.WebfileDcId = WebfileDcId;
            newClonedObject.SuggestedLangCode = SuggestedLangCode;
            newClonedObject.LangPackVersion = LangPackVersion;
            newClonedObject.BaseLangPackVersion = BaseLangPackVersion;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Config castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (PhonecallsEnabled != castedOther.PhonecallsEnabled)
            {
                return true;
            }

            if (DefaultP2pContacts != castedOther.DefaultP2pContacts)
            {
                return true;
            }

            if (PreloadFeaturedStickers != castedOther.PreloadFeaturedStickers)
            {
                return true;
            }

            if (IgnorePhoneEntities != castedOther.IgnorePhoneEntities)
            {
                return true;
            }

            if (RevokePmInbox != castedOther.RevokePmInbox)
            {
                return true;
            }

            if (BlockedMode != castedOther.BlockedMode)
            {
                return true;
            }

            if (PfsEnabled != castedOther.PfsEnabled)
            {
                return true;
            }

            if (ForceTryIpv6 != castedOther.ForceTryIpv6)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (Expires != castedOther.Expires)
            {
                return true;
            }

            if (TestMode != castedOther.TestMode)
            {
                return true;
            }

            if (ThisDc != castedOther.ThisDc)
            {
                return true;
            }

            var dcOptionssize = castedOther.DcOptions.Count;
            if (dcOptionssize != DcOptions.Count)
            {
                return true;
            }

            for (var i = 0; i < dcOptionssize; i++)
            {
                if (castedOther.DcOptions[i].Compare(DcOptions[i]))
                {
                    return true;
                }
            }

            if (DcTxtDomainName != castedOther.DcTxtDomainName)
            {
                return true;
            }

            if (ChatSizeMax != castedOther.ChatSizeMax)
            {
                return true;
            }

            if (MegagroupSizeMax != castedOther.MegagroupSizeMax)
            {
                return true;
            }

            if (ForwardedCountMax != castedOther.ForwardedCountMax)
            {
                return true;
            }

            if (OnlineUpdatePeriodMs != castedOther.OnlineUpdatePeriodMs)
            {
                return true;
            }

            if (OfflineBlurTimeoutMs != castedOther.OfflineBlurTimeoutMs)
            {
                return true;
            }

            if (OfflineIdleTimeoutMs != castedOther.OfflineIdleTimeoutMs)
            {
                return true;
            }

            if (OnlineCloudTimeoutMs != castedOther.OnlineCloudTimeoutMs)
            {
                return true;
            }

            if (NotifyCloudDelayMs != castedOther.NotifyCloudDelayMs)
            {
                return true;
            }

            if (NotifyDefaultDelayMs != castedOther.NotifyDefaultDelayMs)
            {
                return true;
            }

            if (PushChatPeriodMs != castedOther.PushChatPeriodMs)
            {
                return true;
            }

            if (PushChatLimit != castedOther.PushChatLimit)
            {
                return true;
            }

            if (SavedGifsLimit != castedOther.SavedGifsLimit)
            {
                return true;
            }

            if (EditTimeLimit != castedOther.EditTimeLimit)
            {
                return true;
            }

            if (RevokeTimeLimit != castedOther.RevokeTimeLimit)
            {
                return true;
            }

            if (RevokePmTimeLimit != castedOther.RevokePmTimeLimit)
            {
                return true;
            }

            if (RatingEDecay != castedOther.RatingEDecay)
            {
                return true;
            }

            if (StickersRecentLimit != castedOther.StickersRecentLimit)
            {
                return true;
            }

            if (StickersFavedLimit != castedOther.StickersFavedLimit)
            {
                return true;
            }

            if (ChannelsReadMediaPeriod != castedOther.ChannelsReadMediaPeriod)
            {
                return true;
            }

            if (TmpSessions != castedOther.TmpSessions)
            {
                return true;
            }

            if (PinnedDialogsCountMax != castedOther.PinnedDialogsCountMax)
            {
                return true;
            }

            if (PinnedInfolderCountMax != castedOther.PinnedInfolderCountMax)
            {
                return true;
            }

            if (CallReceiveTimeoutMs != castedOther.CallReceiveTimeoutMs)
            {
                return true;
            }

            if (CallRingTimeoutMs != castedOther.CallRingTimeoutMs)
            {
                return true;
            }

            if (CallConnectTimeoutMs != castedOther.CallConnectTimeoutMs)
            {
                return true;
            }

            if (CallPacketTimeoutMs != castedOther.CallPacketTimeoutMs)
            {
                return true;
            }

            if (MeUrlPrefix != castedOther.MeUrlPrefix)
            {
                return true;
            }

            if (AutoupdateUrlPrefix != castedOther.AutoupdateUrlPrefix)
            {
                return true;
            }

            if (GifSearchUsername != castedOther.GifSearchUsername)
            {
                return true;
            }

            if (VenueSearchUsername != castedOther.VenueSearchUsername)
            {
                return true;
            }

            if (ImgSearchUsername != castedOther.ImgSearchUsername)
            {
                return true;
            }

            if (StaticMapsProvider != castedOther.StaticMapsProvider)
            {
                return true;
            }

            if (CaptionLengthMax != castedOther.CaptionLengthMax)
            {
                return true;
            }

            if (MessageLengthMax != castedOther.MessageLengthMax)
            {
                return true;
            }

            if (WebfileDcId != castedOther.WebfileDcId)
            {
                return true;
            }

            if (SuggestedLangCode != castedOther.SuggestedLangCode)
            {
                return true;
            }

            if (LangPackVersion != castedOther.LangPackVersion)
            {
                return true;
            }

            if (BaseLangPackVersion != castedOther.BaseLangPackVersion)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}