using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class GameBase : IObject
	{
		public abstract long Id { get; set; }
		public abstract long AccessHash { get; set; }
		public abstract string ShortName { get; set; }
		public abstract string Title { get; set; }
		public abstract string Description { get; set; }
		public abstract PhotoBase Photo { get; set; }
		public abstract DocumentBase Document { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}