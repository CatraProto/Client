using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MsgDetailedInfoBase : IObject
    {

[Newtonsoft.Json.JsonProperty("answer_msg_id")]
		public abstract long AnswerMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public abstract int Bytes { get; set; }

[Newtonsoft.Json.JsonProperty("status")]
		public abstract int Status { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
