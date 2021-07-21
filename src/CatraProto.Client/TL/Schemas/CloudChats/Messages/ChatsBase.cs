using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class ChatsBase : IObject
    {

[JsonPropertyName("Chats_")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats_ { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
