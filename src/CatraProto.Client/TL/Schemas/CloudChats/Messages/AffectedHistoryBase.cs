using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public abstract class AffectedHistoryBase : IObject
	{
		public abstract int Pts { get; set; }
		public abstract int PtsCount { get; set; }
		public abstract int Offset { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}