using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MsgsStateInfoBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("req_msg_id")]
        public abstract long ReqMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("info")]
        public abstract byte[] Info { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
