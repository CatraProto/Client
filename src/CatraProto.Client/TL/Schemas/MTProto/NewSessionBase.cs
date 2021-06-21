using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public abstract class NewSessionBase : IObject
	{
		public abstract long FirstMsgId { get; set; }
		public abstract long UniqueId { get; set; }
		public abstract long ServerSalt { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}