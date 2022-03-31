using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class PongBase : IObject
    {

[Newtonsoft.Json.JsonProperty("msg_id")]
		public abstract long MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("ping_id")]
		public abstract long PingId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
