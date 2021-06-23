using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public abstract class VotesListBase : IObject
	{
		public abstract int Count { get; set; }
		public abstract IList<MessageUserVoteBase> Votes { get; set; }
		public abstract IList<UserBase> Users { get; set; }
		public abstract string NextOffset { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}