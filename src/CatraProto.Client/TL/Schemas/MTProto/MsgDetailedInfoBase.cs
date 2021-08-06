using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MsgDetailedInfoBase : IObject
    {

[JsonPropertyName("answer_msg_id")]
		public abstract long AnswerMsgId { get; set; }

[JsonPropertyName("bytes")]
		public abstract int Bytes { get; set; }

[JsonPropertyName("status")]
		public abstract int Status { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
