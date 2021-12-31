using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserFull : CatraProto.Client.TL.Schemas.CloudChats.UserFullBase
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
			FolderId = 1 << 11,
			TtlPeriod = 1 << 14,
			ThemeEmoticon = 1 << 15,
			PrivateForwardName = 1 << 16
		}

        public static int StaticConstructorId { get => -818518751; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("blocked")]
		public override bool Blocked { get; set; }

[Newtonsoft.Json.JsonProperty("phone_calls_available")]
		public override bool PhoneCallsAvailable { get; set; }

[Newtonsoft.Json.JsonProperty("phone_calls_private")]
		public override bool PhoneCallsPrivate { get; set; }

[Newtonsoft.Json.JsonProperty("can_pin_message")]
		public override bool CanPinMessage { get; set; }

[Newtonsoft.Json.JsonProperty("has_scheduled")]
		public override bool HasScheduled { get; set; }

[Newtonsoft.Json.JsonProperty("video_calls_available")]
		public override bool VideoCallsAvailable { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("about")]
		public override string About { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }

[Newtonsoft.Json.JsonProperty("profile_photo")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ProfilePhoto { get; set; }

[Newtonsoft.Json.JsonProperty("notify_settings")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

[Newtonsoft.Json.JsonProperty("bot_info")]
		public override CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase BotInfo { get; set; }

[Newtonsoft.Json.JsonProperty("pinned_msg_id")]
		public override int? PinnedMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("common_chats_count")]
		public override int CommonChatsCount { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public override int? FolderId { get; set; }

[Newtonsoft.Json.JsonProperty("ttl_period")]
		public override int? TtlPeriod { get; set; }

[Newtonsoft.Json.JsonProperty("theme_emoticon")]
		public override string ThemeEmoticon { get; set; }

[Newtonsoft.Json.JsonProperty("private_forward_name")]
		public override string PrivateForwardName { get; set; }

        
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
			Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = ThemeEmoticon == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);
			Flags = PrivateForwardName == null ? FlagsHelper.UnsetFlag(Flags, 16) : FlagsHelper.SetFlag(Flags, 16);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(About);
			}

			writer.Write(Settings);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ProfilePhoto);
			}

			writer.Write(NotifySettings);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(BotInfo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(PinnedMsgId.Value);
			}

			writer.Write(CommonChatsCount);
			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(FolderId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				writer.Write(TtlPeriod.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				writer.Write(ThemeEmoticon);
			}

			if(FlagsHelper.IsFlagSet(Flags, 16))
			{
				writer.Write(PrivateForwardName);
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
			Id = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				About = reader.Read<string>();
			}

			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ProfilePhoto = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			}

			NotifySettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				BotInfo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				PinnedMsgId = reader.Read<int>();
			}

			CommonChatsCount = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				FolderId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				TtlPeriod = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				ThemeEmoticon = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 16))
			{
				PrivateForwardName = reader.Read<string>();
			}


		}
				
		public override string ToString()
		{
		    return "userFull";
		}
	}
}