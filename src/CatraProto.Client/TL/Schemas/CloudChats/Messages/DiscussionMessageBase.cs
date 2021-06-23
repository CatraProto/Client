using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public abstract class DiscussionMessageBase : IObject
	{
		public abstract IList<MessageBase> Messages { get; set; }
		public abstract int? MaxId { get; set; }
		public abstract int? ReadInboxMaxId { get; set; }
		public abstract int? ReadOutboxMaxId { get; set; }
		public abstract IList<ChatBase> Chats { get; set; }
		public abstract IList<UserBase> Users { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}