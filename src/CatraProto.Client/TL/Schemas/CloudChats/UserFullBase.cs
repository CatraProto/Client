using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class UserFullBase : IObject
    {

[JsonPropertyName("blocked")]
		public abstract bool Blocked { get; set; }

[JsonPropertyName("phone_calls_available")]
		public abstract bool PhoneCallsAvailable { get; set; }

[JsonPropertyName("phone_calls_private")]
		public abstract bool PhoneCallsPrivate { get; set; }

[JsonPropertyName("can_pin_message")]
		public abstract bool CanPinMessage { get; set; }

[JsonPropertyName("has_scheduled")]
		public abstract bool HasScheduled { get; set; }

[JsonPropertyName("video_calls_available")]
		public abstract bool VideoCallsAvailable { get; set; }

[JsonPropertyName("user")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }

[JsonPropertyName("about")]
		public abstract string About { get; set; }

[JsonPropertyName("settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }

[JsonPropertyName("profile_photo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ProfilePhoto { get; set; }

[JsonPropertyName("notify_settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

[JsonPropertyName("bot_info")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase BotInfo { get; set; }

[JsonPropertyName("pinned_msg_id")]
		public abstract int? PinnedMsgId { get; set; }

[JsonPropertyName("common_chats_count")]
		public abstract int CommonChatsCount { get; set; }

[JsonPropertyName("folder_id")]
		public abstract int? FolderId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
