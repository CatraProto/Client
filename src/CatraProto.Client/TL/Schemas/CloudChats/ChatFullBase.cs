using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatFullBase : IObject
    {

[Newtonsoft.Json.JsonProperty("id")]
		public abstract int Id { get; set; }

[Newtonsoft.Json.JsonProperty("about")]
		public abstract string About { get; set; }

[Newtonsoft.Json.JsonProperty("notify_settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

[Newtonsoft.Json.JsonProperty("exported_invite")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase ExportedInvite { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public abstract int? FolderId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
