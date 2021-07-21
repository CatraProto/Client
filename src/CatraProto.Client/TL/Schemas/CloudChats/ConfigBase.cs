using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ConfigBase : IObject
    {

[JsonPropertyName("phonecalls_enabled")]
		public abstract bool PhonecallsEnabled { get; set; }

[JsonPropertyName("default_p2p_contacts")]
		public abstract bool DefaultP2pContacts { get; set; }

[JsonPropertyName("preload_featured_stickers")]
		public abstract bool PreloadFeaturedStickers { get; set; }

[JsonPropertyName("ignore_phone_entities")]
		public abstract bool IgnorePhoneEntities { get; set; }

[JsonPropertyName("revoke_pm_inbox")]
		public abstract bool RevokePmInbox { get; set; }

[JsonPropertyName("blocked_mode")]
		public abstract bool BlockedMode { get; set; }

[JsonPropertyName("pfs_enabled")]
		public abstract bool PfsEnabled { get; set; }

[JsonPropertyName("date")]
		public abstract int Date { get; set; }

[JsonPropertyName("expires")]
		public abstract int Expires { get; set; }

[JsonPropertyName("test_mode")]
		public abstract bool TestMode { get; set; }

[JsonPropertyName("this_dc")]
		public abstract int ThisDc { get; set; }

[JsonPropertyName("dc_options")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> DcOptions { get; set; }

[JsonPropertyName("dc_txt_domain_name")]
		public abstract string DcTxtDomainName { get; set; }

[JsonPropertyName("chat_size_max")]
		public abstract int ChatSizeMax { get; set; }

[JsonPropertyName("megagroup_size_max")]
		public abstract int MegagroupSizeMax { get; set; }

[JsonPropertyName("forwarded_count_max")]
		public abstract int ForwardedCountMax { get; set; }

[JsonPropertyName("online_update_period_ms")]
		public abstract int OnlineUpdatePeriodMs { get; set; }

[JsonPropertyName("offline_blur_timeout_ms")]
		public abstract int OfflineBlurTimeoutMs { get; set; }

[JsonPropertyName("offline_idle_timeout_ms")]
		public abstract int OfflineIdleTimeoutMs { get; set; }

[JsonPropertyName("online_cloud_timeout_ms")]
		public abstract int OnlineCloudTimeoutMs { get; set; }

[JsonPropertyName("notify_cloud_delay_ms")]
		public abstract int NotifyCloudDelayMs { get; set; }

[JsonPropertyName("notify_default_delay_ms")]
		public abstract int NotifyDefaultDelayMs { get; set; }

[JsonPropertyName("push_chat_period_ms")]
		public abstract int PushChatPeriodMs { get; set; }

[JsonPropertyName("push_chat_limit")]
		public abstract int PushChatLimit { get; set; }

[JsonPropertyName("saved_gifs_limit")]
		public abstract int SavedGifsLimit { get; set; }

[JsonPropertyName("edit_time_limit")]
		public abstract int EditTimeLimit { get; set; }

[JsonPropertyName("revoke_time_limit")]
		public abstract int RevokeTimeLimit { get; set; }

[JsonPropertyName("revoke_pm_time_limit")]
		public abstract int RevokePmTimeLimit { get; set; }

[JsonPropertyName("rating_e_decay")]
		public abstract int RatingEDecay { get; set; }

[JsonPropertyName("stickers_recent_limit")]
		public abstract int StickersRecentLimit { get; set; }

[JsonPropertyName("stickers_faved_limit")]
		public abstract int StickersFavedLimit { get; set; }

[JsonPropertyName("channels_read_media_period")]
		public abstract int ChannelsReadMediaPeriod { get; set; }

[JsonPropertyName("tmp_sessions")]
		public abstract int? TmpSessions { get; set; }

[JsonPropertyName("pinned_dialogs_count_max")]
		public abstract int PinnedDialogsCountMax { get; set; }

[JsonPropertyName("pinned_infolder_count_max")]
		public abstract int PinnedInfolderCountMax { get; set; }

[JsonPropertyName("call_receive_timeout_ms")]
		public abstract int CallReceiveTimeoutMs { get; set; }

[JsonPropertyName("call_ring_timeout_ms")]
		public abstract int CallRingTimeoutMs { get; set; }

[JsonPropertyName("call_connect_timeout_ms")]
		public abstract int CallConnectTimeoutMs { get; set; }

[JsonPropertyName("call_packet_timeout_ms")]
		public abstract int CallPacketTimeoutMs { get; set; }

[JsonPropertyName("me_url_prefix")]
		public abstract string MeUrlPrefix { get; set; }

[JsonPropertyName("autoupdate_url_prefix")]
		public abstract string AutoupdateUrlPrefix { get; set; }

[JsonPropertyName("gif_search_username")]
		public abstract string GifSearchUsername { get; set; }

[JsonPropertyName("venue_search_username")]
		public abstract string VenueSearchUsername { get; set; }

[JsonPropertyName("img_search_username")]
		public abstract string ImgSearchUsername { get; set; }

[JsonPropertyName("static_maps_provider")]
		public abstract string StaticMapsProvider { get; set; }

[JsonPropertyName("caption_length_max")]
		public abstract int CaptionLengthMax { get; set; }

[JsonPropertyName("message_length_max")]
		public abstract int MessageLengthMax { get; set; }

[JsonPropertyName("webfile_dc_id")]
		public abstract int WebfileDcId { get; set; }

[JsonPropertyName("suggested_lang_code")]
		public abstract string SuggestedLangCode { get; set; }

[JsonPropertyName("lang_pack_version")]
		public abstract int? LangPackVersion { get; set; }

[JsonPropertyName("base_lang_pack_version")]
		public abstract int? BaseLangPackVersion { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
