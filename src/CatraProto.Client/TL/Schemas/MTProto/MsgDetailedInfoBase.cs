using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
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
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
