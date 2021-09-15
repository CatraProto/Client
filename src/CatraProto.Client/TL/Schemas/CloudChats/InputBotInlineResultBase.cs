using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputBotInlineResultBase : IObject
    {

[Newtonsoft.Json.JsonProperty("id")]
		public abstract string Id { get; set; }

[Newtonsoft.Json.JsonProperty("send_message")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
