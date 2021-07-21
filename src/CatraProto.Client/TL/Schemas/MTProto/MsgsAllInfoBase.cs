using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MsgsAllInfoBase : IObject
    {

[JsonPropertyName("msg_ids")]
		public abstract IList<long> MsgIds { get; set; }

[JsonPropertyName("info")]
		public abstract byte[] Info { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
