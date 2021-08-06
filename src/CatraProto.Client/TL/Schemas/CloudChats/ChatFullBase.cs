using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatFullBase : IObject
    {

[JsonPropertyName("can_set_username")]
		public abstract bool CanSetUsername { get; set; }

[JsonPropertyName("has_scheduled")]
		public abstract bool HasScheduled { get; set; }

[JsonPropertyName("id")]
		public abstract int Id { get; set; }

[JsonPropertyName("about")]
		public abstract string About { get; set; }

[JsonPropertyName("chat_photo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ChatPhoto { get; set; }

[JsonPropertyName("notify_settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

[JsonPropertyName("exported_invite")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase ExportedInvite { get; set; }

[JsonPropertyName("bot_info")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase> BotInfo { get; set; }

[JsonPropertyName("pinned_msg_id")]
		public abstract int? PinnedMsgId { get; set; }

[JsonPropertyName("folder_id")]
		public abstract int? FolderId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
