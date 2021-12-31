using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class DiscussionMessageBase : IObject
    {

[Newtonsoft.Json.JsonProperty("messages")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public abstract int? MaxId { get; set; }

[Newtonsoft.Json.JsonProperty("read_inbox_max_id")]
		public abstract int? ReadInboxMaxId { get; set; }

[Newtonsoft.Json.JsonProperty("read_outbox_max_id")]
		public abstract int? ReadOutboxMaxId { get; set; }

[Newtonsoft.Json.JsonProperty("unread_count")]
		public abstract int UnreadCount { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
