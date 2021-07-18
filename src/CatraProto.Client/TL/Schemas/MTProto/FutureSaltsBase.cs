using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.MTProto;


namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class FutureSaltsBase : IObject
    {
		public abstract long ReqMsgId { get; set; }
		public abstract int Now { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.MTProto.FutureSalt> Salts { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
