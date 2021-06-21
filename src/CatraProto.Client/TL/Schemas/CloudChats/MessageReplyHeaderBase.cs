using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class MessageReplyHeaderBase : IObject
	{
		public abstract int ReplyToMsgId { get; set; }
		public abstract PeerBase ReplyToPeerId { get; set; }
		public abstract int? ReplyToTopId { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}