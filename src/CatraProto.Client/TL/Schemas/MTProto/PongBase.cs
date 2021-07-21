using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class PongBase : IObject
    {

[JsonPropertyName("msg_id")]
		public abstract long MsgId { get; set; }

[JsonPropertyName("ping_id")]
		public abstract long PingId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
