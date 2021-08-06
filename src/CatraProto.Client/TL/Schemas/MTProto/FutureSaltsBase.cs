using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class FutureSaltsBase : IObject
    {

[JsonPropertyName("req_msg_id")]
		public abstract long ReqMsgId { get; set; }

[JsonPropertyName("now")]
		public abstract int Now { get; set; }

[JsonPropertyName("salts")]
		public abstract IList<CatraProto.Client.TL.Schemas.MTProto.FutureSalt> Salts { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
