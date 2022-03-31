using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageInteractionCountersBase : IObject
    {

[Newtonsoft.Json.JsonProperty("msg_id")]
		public abstract int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("views")]
		public abstract int Views { get; set; }

[Newtonsoft.Json.JsonProperty("forwards")]
		public abstract int Forwards { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
