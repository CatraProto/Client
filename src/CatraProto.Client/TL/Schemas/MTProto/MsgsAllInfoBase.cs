using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MsgsAllInfoBase : IObject
    {

[Newtonsoft.Json.JsonProperty("msg_ids")]
		public abstract IList<long> MsgIds { get; set; }

[Newtonsoft.Json.JsonProperty("info")]
		public abstract byte[] Info { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
