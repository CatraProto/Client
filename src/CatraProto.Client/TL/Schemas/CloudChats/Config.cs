using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 856375399; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

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

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("expires")]
		public sealed override int Expires { get; set; }

[Newtonsoft.Json.JsonProperty("test_mode")]
		public sealed override bool TestMode { get; set; }

[Newtonsoft.Json.JsonProperty("this_dc")]
		public sealed override int ThisDc { get; set; }

[Newtonsoft.Json.JsonProperty("dc_options")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> DcOptions { get; set; }

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

[Newtonsoft.Json.JsonProperty("autoupdate_url_prefix")]
		public sealed override string AutoupdateUrlPrefix { get; set; }

[Newtonsoft.Json.JsonProperty("gif_search_username")]
		public sealed override string GifSearchUsername { get; set; }

[Newtonsoft.Json.JsonProperty("venue_search_username")]
		public sealed override string VenueSearchUsername { get; set; }

[Newtonsoft.Json.JsonProperty("img_search_username")]
		public sealed override string ImgSearchUsername { get; set; }

[Newtonsoft.Json.JsonProperty("static_maps_provider")]
		public sealed override string StaticMapsProvider { get; set; }

[Newtonsoft.Json.JsonProperty("caption_length_max")]
		public sealed override int CaptionLengthMax { get; set; }

[Newtonsoft.Json.JsonProperty("message_length_max")]
		public sealed override int MessageLengthMax { get; set; }

[Newtonsoft.Json.JsonProperty("webfile_dc_id")]
		public sealed override int WebfileDcId { get; set; }

[Newtonsoft.Json.JsonProperty("suggested_lang_code")]
		public sealed override string SuggestedLangCode { get; set; }

[Newtonsoft.Json.JsonProperty("lang_pack_version")]
		public sealed override int? LangPackVersion { get; set; }

[Newtonsoft.Json.JsonProperty("base_lang_pack_version")]
		public sealed override int? BaseLangPackVersion { get; set; }


        #nullable enable
 public Config (int date,int expires,bool testMode,int thisDc,IList<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> dcOptions,string dcTxtDomainName,int chatSizeMax,int megagroupSizeMax,int forwardedCountMax,int onlineUpdatePeriodMs,int offlineBlurTimeoutMs,int offlineIdleTimeoutMs,int onlineCloudTimeoutMs,int notifyCloudDelayMs,int notifyDefaultDelayMs,int pushChatPeriodMs,int pushChatLimit,int savedGifsLimit,int editTimeLimit,int revokeTimeLimit,int revokePmTimeLimit,int ratingEDecay,int stickersRecentLimit,int stickersFavedLimit,int channelsReadMediaPeriod,int pinnedDialogsCountMax,int pinnedInfolderCountMax,int callReceiveTimeoutMs,int callRingTimeoutMs,int callConnectTimeoutMs,int callPacketTimeoutMs,string meUrlPrefix,int captionLengthMax,int messageLengthMax,int webfileDcId)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Date);
			writer.Write(Expires);
			writer.Write(TestMode);
			writer.Write(ThisDc);
			writer.Write(DcOptions);
			writer.Write(DcTxtDomainName);
			writer.Write(ChatSizeMax);
			writer.Write(MegagroupSizeMax);
			writer.Write(ForwardedCountMax);
			writer.Write(OnlineUpdatePeriodMs);
			writer.Write(OfflineBlurTimeoutMs);
			writer.Write(OfflineIdleTimeoutMs);
			writer.Write(OnlineCloudTimeoutMs);
			writer.Write(NotifyCloudDelayMs);
			writer.Write(NotifyDefaultDelayMs);
			writer.Write(PushChatPeriodMs);
			writer.Write(PushChatLimit);
			writer.Write(SavedGifsLimit);
			writer.Write(EditTimeLimit);
			writer.Write(RevokeTimeLimit);
			writer.Write(RevokePmTimeLimit);
			writer.Write(RatingEDecay);
			writer.Write(StickersRecentLimit);
			writer.Write(StickersFavedLimit);
			writer.Write(ChannelsReadMediaPeriod);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TmpSessions.Value);
			}

			writer.Write(PinnedDialogsCountMax);
			writer.Write(PinnedInfolderCountMax);
			writer.Write(CallReceiveTimeoutMs);
			writer.Write(CallRingTimeoutMs);
			writer.Write(CallConnectTimeoutMs);
			writer.Write(CallPacketTimeoutMs);
			writer.Write(MeUrlPrefix);
			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(AutoupdateUrlPrefix);
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				writer.Write(GifSearchUsername);
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(VenueSearchUsername);
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(ImgSearchUsername);
			}

			if(FlagsHelper.IsFlagSet(Flags, 12))
			{
				writer.Write(StaticMapsProvider);
			}

			writer.Write(CaptionLengthMax);
			writer.Write(MessageLengthMax);
			writer.Write(WebfileDcId);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(SuggestedLangCode);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(LangPackVersion.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(BaseLangPackVersion.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			PhonecallsEnabled = FlagsHelper.IsFlagSet(Flags, 1);
			DefaultP2pContacts = FlagsHelper.IsFlagSet(Flags, 3);
			PreloadFeaturedStickers = FlagsHelper.IsFlagSet(Flags, 4);
			IgnorePhoneEntities = FlagsHelper.IsFlagSet(Flags, 5);
			RevokePmInbox = FlagsHelper.IsFlagSet(Flags, 6);
			BlockedMode = FlagsHelper.IsFlagSet(Flags, 8);
			PfsEnabled = FlagsHelper.IsFlagSet(Flags, 13);
			Date = reader.Read<int>();
			Expires = reader.Read<int>();
			TestMode = reader.Read<bool>();
			ThisDc = reader.Read<int>();
			DcOptions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase>();
			DcTxtDomainName = reader.Read<string>();
			ChatSizeMax = reader.Read<int>();
			MegagroupSizeMax = reader.Read<int>();
			ForwardedCountMax = reader.Read<int>();
			OnlineUpdatePeriodMs = reader.Read<int>();
			OfflineBlurTimeoutMs = reader.Read<int>();
			OfflineIdleTimeoutMs = reader.Read<int>();
			OnlineCloudTimeoutMs = reader.Read<int>();
			NotifyCloudDelayMs = reader.Read<int>();
			NotifyDefaultDelayMs = reader.Read<int>();
			PushChatPeriodMs = reader.Read<int>();
			PushChatLimit = reader.Read<int>();
			SavedGifsLimit = reader.Read<int>();
			EditTimeLimit = reader.Read<int>();
			RevokeTimeLimit = reader.Read<int>();
			RevokePmTimeLimit = reader.Read<int>();
			RatingEDecay = reader.Read<int>();
			StickersRecentLimit = reader.Read<int>();
			StickersFavedLimit = reader.Read<int>();
			ChannelsReadMediaPeriod = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				TmpSessions = reader.Read<int>();
			}

			PinnedDialogsCountMax = reader.Read<int>();
			PinnedInfolderCountMax = reader.Read<int>();
			CallReceiveTimeoutMs = reader.Read<int>();
			CallRingTimeoutMs = reader.Read<int>();
			CallConnectTimeoutMs = reader.Read<int>();
			CallPacketTimeoutMs = reader.Read<int>();
			MeUrlPrefix = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				AutoupdateUrlPrefix = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				GifSearchUsername = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				VenueSearchUsername = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				ImgSearchUsername = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 12))
			{
				StaticMapsProvider = reader.Read<string>();
			}

			CaptionLengthMax = reader.Read<int>();
			MessageLengthMax = reader.Read<int>();
			WebfileDcId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				SuggestedLangCode = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				LangPackVersion = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				BaseLangPackVersion = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "config";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}