using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class PeerDialogsBase : IObject
    {
        [JsonProperty("dialogs")] public abstract IList<DialogBase> Dialogs { get; set; }

        [JsonProperty("messages")] public abstract IList<MessageBase> Messages { get; set; }

        [JsonProperty("chats")] public abstract IList<ChatBase> Chats { get; set; }

        [JsonProperty("users")] public abstract IList<UserBase> Users { get; set; }

        [JsonProperty("state")] public abstract StateBase State { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}