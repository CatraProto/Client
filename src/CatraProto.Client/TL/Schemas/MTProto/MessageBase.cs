using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MessageBase : IObject
    {

[JsonPropertyName("msg_id")]
		public abstract long MsgId { get; set; }

[JsonPropertyName("seqno")]
		public abstract int Seqno { get; set; }

[JsonPropertyName("bytes")]
		public abstract int Bytes { get; set; }

[JsonPropertyName("body")]
		public abstract IObject Body { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
