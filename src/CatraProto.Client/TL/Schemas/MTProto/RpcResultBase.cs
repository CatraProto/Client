using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class RpcResultBase : IObject
    {

[Newtonsoft.Json.JsonProperty("req_msg_id")]
		public abstract long ReqMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("result")]
		public abstract IObject Result { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
