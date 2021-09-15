using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class FutureSaltsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("req_msg_id")]
		public abstract long ReqMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("now")]
		public abstract int Now { get; set; }

[Newtonsoft.Json.JsonProperty("salts")]
		public abstract IList<CatraProto.Client.TL.Schemas.MTProto.FutureSalt> Salts { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
