using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ConfigBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("phonecalls_enabled")]
        public abstract bool PhonecallsEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("default_p2p_contacts")]
        public abstract bool DefaultP2pContacts { get; set; }

        [Newtonsoft.Json.JsonProperty("preload_featured_stickers")]
        public abstract bool PreloadFeaturedStickers { get; set; }

        [Newtonsoft.Json.JsonProperty("ignore_phone_entities")]
        public abstract bool IgnorePhoneEntities { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke_pm_inbox")]
        public abstract bool RevokePmInbox { get; set; }

        [Newtonsoft.Json.JsonProperty("blocked_mode")]
        public abstract bool BlockedMode { get; set; }

        [Newtonsoft.Json.JsonProperty("pfs_enabled")]
        public abstract bool PfsEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("force_try_ipv6")]
        public abstract bool ForceTryIpv6 { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public abstract int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public abstract int Expires { get; set; }

        [Newtonsoft.Json.JsonProperty("test_mode")]
        public abstract bool TestMode { get; set; }

        [Newtonsoft.Json.JsonProperty("this_dc")]
        public abstract int ThisDc { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_options")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> DcOptions { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_txt_domain_name")]
        public abstract string DcTxtDomainName { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_size_max")]
        public abstract int ChatSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("megagroup_size_max")]
        public abstract int MegagroupSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("forwarded_count_max")]
        public abstract int ForwardedCountMax { get; set; }

        [Newtonsoft.Json.JsonProperty("online_update_period_ms")]
        public abstract int OnlineUpdatePeriodMs { get; set; }

        [Newtonsoft.Json.JsonProperty("offline_blur_timeout_ms")]
        public abstract int OfflineBlurTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("offline_idle_timeout_ms")]
        public abstract int OfflineIdleTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("online_cloud_timeout_ms")]
        public abstract int OnlineCloudTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_cloud_delay_ms")]
        public abstract int NotifyCloudDelayMs { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_default_delay_ms")]
        public abstract int NotifyDefaultDelayMs { get; set; }

        [Newtonsoft.Json.JsonProperty("push_chat_period_ms")]
        public abstract int PushChatPeriodMs { get; set; }

        [Newtonsoft.Json.JsonProperty("push_chat_limit")]
        public abstract int PushChatLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("saved_gifs_limit")]
        public abstract int SavedGifsLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("edit_time_limit")]
        public abstract int EditTimeLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke_time_limit")]
        public abstract int RevokeTimeLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke_pm_time_limit")]
        public abstract int RevokePmTimeLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("rating_e_decay")]
        public abstract int RatingEDecay { get; set; }

        [Newtonsoft.Json.JsonProperty("stickers_recent_limit")]
        public abstract int StickersRecentLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("stickers_faved_limit")]
        public abstract int StickersFavedLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("channels_read_media_period")]
        public abstract int ChannelsReadMediaPeriod { get; set; }

        [Newtonsoft.Json.JsonProperty("tmp_sessions")]
        public abstract int? TmpSessions { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_dialogs_count_max")]
        public abstract int PinnedDialogsCountMax { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_infolder_count_max")]
        public abstract int PinnedInfolderCountMax { get; set; }

        [Newtonsoft.Json.JsonProperty("call_receive_timeout_ms")]
        public abstract int CallReceiveTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("call_ring_timeout_ms")]
        public abstract int CallRingTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("call_connect_timeout_ms")]
        public abstract int CallConnectTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("call_packet_timeout_ms")]
        public abstract int CallPacketTimeoutMs { get; set; }

        [Newtonsoft.Json.JsonProperty("me_url_prefix")]
        public abstract string MeUrlPrefix { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("autoupdate_url_prefix")]
        public abstract string AutoupdateUrlPrefix { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("gif_search_username")]
        public abstract string GifSearchUsername { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("venue_search_username")]
        public abstract string VenueSearchUsername { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("img_search_username")]
        public abstract string ImgSearchUsername { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("static_maps_provider")]
        public abstract string StaticMapsProvider { get; set; }

        [Newtonsoft.Json.JsonProperty("caption_length_max")]
        public abstract int CaptionLengthMax { get; set; }

        [Newtonsoft.Json.JsonProperty("message_length_max")]
        public abstract int MessageLengthMax { get; set; }

        [Newtonsoft.Json.JsonProperty("webfile_dc_id")]
        public abstract int WebfileDcId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("suggested_lang_code")]
        public abstract string SuggestedLangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_pack_version")]
        public abstract int? LangPackVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("base_lang_pack_version")]
        public abstract int? BaseLangPackVersion { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}