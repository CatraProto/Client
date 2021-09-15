using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public abstract class AdminLogResultsBase : IObject
    {
        [JsonProperty("events")] public abstract IList<ChannelAdminLogEventBase> Events { get; set; }

        [JsonProperty("chats")] public abstract IList<ChatBase> Chats { get; set; }

        [JsonProperty("users")] public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}