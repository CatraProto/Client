using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class DiscussionMessageBase : IObject
    {
        [JsonProperty("messages")] public abstract IList<MessageBase> Messages { get; set; }

        [JsonProperty("max_id")] public abstract int? MaxId { get; set; }

        [JsonProperty("read_inbox_max_id")] public abstract int? ReadInboxMaxId { get; set; }

        [JsonProperty("read_outbox_max_id")] public abstract int? ReadOutboxMaxId { get; set; }

        [JsonProperty("chats")] public abstract IList<ChatBase> Chats { get; set; }

        [JsonProperty("users")] public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}