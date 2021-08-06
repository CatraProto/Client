using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class DiscussionMessageBase : IObject
    {

[JsonPropertyName("messages")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[JsonPropertyName("max_id")]
		public abstract int? MaxId { get; set; }

[JsonPropertyName("read_inbox_max_id")]
		public abstract int? ReadInboxMaxId { get; set; }

[JsonPropertyName("read_outbox_max_id")]
		public abstract int? ReadOutboxMaxId { get; set; }

[JsonPropertyName("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
