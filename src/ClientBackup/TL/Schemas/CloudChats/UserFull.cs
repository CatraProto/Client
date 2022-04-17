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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -818518751; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("blocked")]
		public sealed override bool Blocked { get; set; }

[Newtonsoft.Json.JsonProperty("phone_calls_available")]
		public sealed override bool PhoneCallsAvailable { get; set; }

[Newtonsoft.Json.JsonProperty("phone_calls_private")]
		public sealed override bool PhoneCallsPrivate { get; set; }

[Newtonsoft.Json.JsonProperty("can_pin_message")]
		public sealed override bool CanPinMessage { get; set; }

[Newtonsoft.Json.JsonProperty("has_scheduled")]
		public sealed override bool HasScheduled { get; set; }

[Newtonsoft.Json.JsonProperty("video_calls_available")]
		public sealed override bool VideoCallsAvailable { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("about")]
		public sealed override string About { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("profile_photo")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ProfilePhoto { get; set; }

[Newtonsoft.Json.JsonProperty("notify_settings")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("bot_info")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase BotInfo { get; set; }

[Newtonsoft.Json.JsonProperty("pinned_msg_id")]
		public sealed override int? PinnedMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("common_chats_count")]
		public sealed override int CommonChatsCount { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public sealed override int? FolderId { get; set; }

[Newtonsoft.Json.JsonProperty("ttl_period")]
		public sealed override int? TtlPeriod { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("theme_emoticon")]
		public sealed override string ThemeEmoticon { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("private_forward_name")]
		public sealed override string PrivateForwardName { get; set; }


        #nullable enable
 public UserFull (long id,CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase settings,CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase notifySettings,int commonChatsCount)
{
 Id = id;
Settings = settings;
NotifySettings = notifySettings;
CommonChatsCount = commonChatsCount;
 
}
#nullable disable
        internal UserFull() 
        {
        }
		
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt64(Id);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{

				writer.WriteString(About);
			}

var checksettings = 			writer.WriteObject(Settings);
if(checksettings.IsError){
 return checksettings; 
}
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
var checkprofilePhoto = 				writer.WriteObject(ProfilePhoto);
if(checkprofilePhoto.IsError){
 return checkprofilePhoto; 
}
			}

var checknotifySettings = 			writer.WriteObject(NotifySettings);
if(checknotifySettings.IsError){
 return checknotifySettings; 
}
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
var checkbotInfo = 				writer.WriteObject(BotInfo);
if(checkbotInfo.IsError){
 return checkbotInfo; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
writer.WriteInt32(PinnedMsgId.Value);
			}

writer.WriteInt32(CommonChatsCount);
			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
writer.WriteInt32(FolderId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
writer.WriteInt32(TtlPeriod.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{

				writer.WriteString(ThemeEmoticon);
			}

			if(FlagsHelper.IsFlagSet(Flags, 16))
			{

				writer.WriteString(PrivateForwardName);
			}


return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			Blocked = FlagsHelper.IsFlagSet(Flags, 0);
			PhoneCallsAvailable = FlagsHelper.IsFlagSet(Flags, 4);
			PhoneCallsPrivate = FlagsHelper.IsFlagSet(Flags, 5);
			CanPinMessage = FlagsHelper.IsFlagSet(Flags, 7);
			HasScheduled = FlagsHelper.IsFlagSet(Flags, 12);
			VideoCallsAvailable = FlagsHelper.IsFlagSet(Flags, 13);
			var tryid = reader.ReadInt64();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var tryabout = reader.ReadString();
if(tryabout.IsError){
return ReadResult<IObject>.Move(tryabout);
}
About = tryabout.Value;
			}

			var trysettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>();
if(trysettings.IsError){
return ReadResult<IObject>.Move(trysettings);
}
Settings = trysettings.Value;
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var tryprofilePhoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
if(tryprofilePhoto.IsError){
return ReadResult<IObject>.Move(tryprofilePhoto);
}
ProfilePhoto = tryprofilePhoto.Value;
			}

			var trynotifySettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
if(trynotifySettings.IsError){
return ReadResult<IObject>.Move(trynotifySettings);
}
NotifySettings = trynotifySettings.Value;
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var trybotInfo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>();
if(trybotInfo.IsError){
return ReadResult<IObject>.Move(trybotInfo);
}
BotInfo = trybotInfo.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				var trypinnedMsgId = reader.ReadInt32();
if(trypinnedMsgId.IsError){
return ReadResult<IObject>.Move(trypinnedMsgId);
}
PinnedMsgId = trypinnedMsgId.Value;
			}

			var trycommonChatsCount = reader.ReadInt32();
if(trycommonChatsCount.IsError){
return ReadResult<IObject>.Move(trycommonChatsCount);
}
CommonChatsCount = trycommonChatsCount.Value;
			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				var tryfolderId = reader.ReadInt32();
if(tryfolderId.IsError){
return ReadResult<IObject>.Move(tryfolderId);
}
FolderId = tryfolderId.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				var tryttlPeriod = reader.ReadInt32();
if(tryttlPeriod.IsError){
return ReadResult<IObject>.Move(tryttlPeriod);
}
TtlPeriod = tryttlPeriod.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 15))
			{
				var trythemeEmoticon = reader.ReadString();
if(trythemeEmoticon.IsError){
return ReadResult<IObject>.Move(trythemeEmoticon);
}
ThemeEmoticon = trythemeEmoticon.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 16))
			{
				var tryprivateForwardName = reader.ReadString();
if(tryprivateForwardName.IsError){
return ReadResult<IObject>.Move(tryprivateForwardName);
}
PrivateForwardName = tryprivateForwardName.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "userFull";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}