using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class UserFullBase : IObject
    {

[Newtonsoft.Json.JsonProperty("blocked")]
		public abstract bool Blocked { get; set; }

[Newtonsoft.Json.JsonProperty("phone_calls_available")]
		public abstract bool PhoneCallsAvailable { get; set; }

[Newtonsoft.Json.JsonProperty("phone_calls_private")]
		public abstract bool PhoneCallsPrivate { get; set; }

[Newtonsoft.Json.JsonProperty("can_pin_message")]
		public abstract bool CanPinMessage { get; set; }

[Newtonsoft.Json.JsonProperty("has_scheduled")]
		public abstract bool HasScheduled { get; set; }

[Newtonsoft.Json.JsonProperty("video_calls_available")]
		public abstract bool VideoCallsAvailable { get; set; }

[Newtonsoft.Json.JsonProperty("user")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }

[Newtonsoft.Json.JsonProperty("about")]
		public abstract string About { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }

[Newtonsoft.Json.JsonProperty("profile_photo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ProfilePhoto { get; set; }

[Newtonsoft.Json.JsonProperty("notify_settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

[Newtonsoft.Json.JsonProperty("bot_info")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase BotInfo { get; set; }

[Newtonsoft.Json.JsonProperty("pinned_msg_id")]
		public abstract int? PinnedMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("common_chats_count")]
		public abstract int CommonChatsCount { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public abstract int? FolderId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
