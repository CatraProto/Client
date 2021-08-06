using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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

        public static int StaticConstructorId { get => 856375399; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("phonecalls_enabled")]
		public override bool PhonecallsEnabled { get; set; }

[JsonPropertyName("default_p2p_contacts")]
		public override bool DefaultP2pContacts { get; set; }

[JsonPropertyName("preload_featured_stickers")]
		public override bool PreloadFeaturedStickers { get; set; }

[JsonPropertyName("ignore_phone_entities")]
		public override bool IgnorePhoneEntities { get; set; }

[JsonPropertyName("revoke_pm_inbox")]
		public override bool RevokePmInbox { get; set; }

[JsonPropertyName("blocked_mode")]
		public override bool BlockedMode { get; set; }

[JsonPropertyName("pfs_enabled")]
		public override bool PfsEnabled { get; set; }

[JsonPropertyName("date")]
		public override int Date { get; set; }

[JsonPropertyName("expires")]
		public override int Expires { get; set; }

[JsonPropertyName("test_mode")]
		public override bool TestMode { get; set; }

[JsonPropertyName("this_dc")]
		public override int ThisDc { get; set; }

[JsonPropertyName("dc_options")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> DcOptions { get; set; }

[JsonPropertyName("dc_txt_domain_name")]
		public override string DcTxtDomainName { get; set; }

[JsonPropertyName("chat_size_max")]
		public override int ChatSizeMax { get; set; }

[JsonPropertyName("megagroup_size_max")]
		public override int MegagroupSizeMax { get; set; }

[JsonPropertyName("forwarded_count_max")]
		public override int ForwardedCountMax { get; set; }

[JsonPropertyName("online_update_period_ms")]
		public override int OnlineUpdatePeriodMs { get; set; }

[JsonPropertyName("offline_blur_timeout_ms")]
		public override int OfflineBlurTimeoutMs { get; set; }

[JsonPropertyName("offline_idle_timeout_ms")]
		public override int OfflineIdleTimeoutMs { get; set; }

[JsonPropertyName("online_cloud_timeout_ms")]
		public override int OnlineCloudTimeoutMs { get; set; }

[JsonPropertyName("notify_cloud_delay_ms")]
		public override int NotifyCloudDelayMs { get; set; }

[JsonPropertyName("notify_default_delay_ms")]
		public override int NotifyDefaultDelayMs { get; set; }

[JsonPropertyName("push_chat_period_ms")]
		public override int PushChatPeriodMs { get; set; }

[JsonPropertyName("push_chat_limit")]
		public override int PushChatLimit { get; set; }

[JsonPropertyName("saved_gifs_limit")]
		public override int SavedGifsLimit { get; set; }

[JsonPropertyName("edit_time_limit")]
		public override int EditTimeLimit { get; set; }

[JsonPropertyName("revoke_time_limit")]
		public override int RevokeTimeLimit { get; set; }

[JsonPropertyName("revoke_pm_time_limit")]
		public override int RevokePmTimeLimit { get; set; }

[JsonPropertyName("rating_e_decay")]
		public override int RatingEDecay { get; set; }

[JsonPropertyName("stickers_recent_limit")]
		public override int StickersRecentLimit { get; set; }

[JsonPropertyName("stickers_faved_limit")]
		public override int StickersFavedLimit { get; set; }

[JsonPropertyName("channels_read_media_period")]
		public override int ChannelsReadMediaPeriod { get; set; }

[JsonPropertyName("tmp_sessions")]
		public override int? TmpSessions { get; set; }

[JsonPropertyName("pinned_dialogs_count_max")]
		public override int PinnedDialogsCountMax { get; set; }

[JsonPropertyName("pinned_infolder_count_max")]
		public override int PinnedInfolderCountMax { get; set; }

[JsonPropertyName("call_receive_timeout_ms")]
		public override int CallReceiveTimeoutMs { get; set; }

[JsonPropertyName("call_ring_timeout_ms")]
		public override int CallRingTimeoutMs { get; set; }

[JsonPropertyName("call_connect_timeout_ms")]
		public override int CallConnectTimeoutMs { get; set; }

[JsonPropertyName("call_packet_timeout_ms")]
		public override int CallPacketTimeoutMs { get; set; }

[JsonPropertyName("me_url_prefix")]
		public override string MeUrlPrefix { get; set; }

[JsonPropertyName("autoupdate_url_prefix")]
		public override string AutoupdateUrlPrefix { get; set; }

[JsonPropertyName("gif_search_username")]
		public override string GifSearchUsername { get; set; }

[JsonPropertyName("venue_search_username")]
		public override string VenueSearchUsername { get; set; }

[JsonPropertyName("img_search_username")]
		public override string ImgSearchUsername { get; set; }

[JsonPropertyName("static_maps_provider")]
		public override string StaticMapsProvider { get; set; }

[JsonPropertyName("caption_length_max")]
		public override int CaptionLengthMax { get; set; }

[JsonPropertyName("message_length_max")]
		public override int MessageLengthMax { get; set; }

[JsonPropertyName("webfile_dc_id")]
		public override int WebfileDcId { get; set; }

[JsonPropertyName("suggested_lang_code")]
		public override string SuggestedLangCode { get; set; }

[JsonPropertyName("lang_pack_version")]
		public override int? LangPackVersion { get; set; }

[JsonPropertyName("base_lang_pack_version")]
		public override int? BaseLangPackVersion { get; set; }

        
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
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}