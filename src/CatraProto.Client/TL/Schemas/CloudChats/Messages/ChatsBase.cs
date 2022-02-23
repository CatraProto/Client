using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class ChatsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> ChatsField { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
