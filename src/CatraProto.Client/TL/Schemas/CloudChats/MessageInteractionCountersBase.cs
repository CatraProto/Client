using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageInteractionCountersBase : IObject
    {

[JsonPropertyName("msg_id")]
		public abstract int MsgId { get; set; }

[JsonPropertyName("views")]
		public abstract int Views { get; set; }

[JsonPropertyName("forwards")]
		public abstract int Forwards { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
