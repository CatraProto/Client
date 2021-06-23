using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class MessageViewsBase : IObject
	{
		public abstract int? Views { get; set; }
		public abstract int? Forwards { get; set; }
		public abstract MessageRepliesBase Replies { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}