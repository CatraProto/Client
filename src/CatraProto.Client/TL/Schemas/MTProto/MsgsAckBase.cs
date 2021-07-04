using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MsgsAckBase : IObject
    {
		public abstract IList<long> MsgIds { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
