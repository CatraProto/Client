using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class DialogBase : IObject
	{
		public abstract bool Pinned { get; set; }
		public abstract PeerBase Peer { get; set; }
		public abstract int TopMessage { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}