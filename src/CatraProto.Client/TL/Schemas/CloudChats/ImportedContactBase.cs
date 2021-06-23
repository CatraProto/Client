using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class ImportedContactBase : IObject
	{
		public abstract int UserId { get; set; }
		public abstract long ClientId { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}