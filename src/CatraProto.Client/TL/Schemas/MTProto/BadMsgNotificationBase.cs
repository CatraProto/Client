using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class BadMsgNotificationBase : IObject
    {

[Newtonsoft.Json.JsonProperty("bad_msg_id")]
		public abstract long BadMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("bad_msg_seqno")]
		public abstract int BadMsgSeqno { get; set; }

[Newtonsoft.Json.JsonProperty("error_code")]
		public abstract int ErrorCode { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
