using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MsgsStateInfoBase : IObject
    {

[JsonPropertyName("req_msg_id")]
		public abstract long ReqMsgId { get; set; }

[JsonPropertyName("info")]
		public abstract byte[] Info { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
