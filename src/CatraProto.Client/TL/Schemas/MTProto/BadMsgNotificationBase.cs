using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class BadMsgNotificationBase : IObject
    {

[JsonPropertyName("bad_msg_id")]
		public abstract long BadMsgId { get; set; }

[JsonPropertyName("bad_msg_seqno")]
		public abstract int BadMsgSeqno { get; set; }

[JsonPropertyName("error_code")]
		public abstract int ErrorCode { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
