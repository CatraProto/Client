using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public abstract class FutureSaltsBase : IObject
	{
		public abstract long ReqMsgId { get; set; }
		public abstract int Now { get; set; }
		public abstract IList<FutureSaltBase> Salts { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}