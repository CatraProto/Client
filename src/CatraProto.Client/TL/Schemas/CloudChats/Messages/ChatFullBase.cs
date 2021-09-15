using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class ChatFullBase : IObject
    {
        [JsonProperty("full_chat")] public abstract CloudChats.ChatFullBase FullChat { get; set; }

        [JsonProperty("chats")] public abstract IList<ChatBase> Chats { get; set; }

        [JsonProperty("users")] public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}