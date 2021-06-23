using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class PollBase : IObject
	{
		public abstract long Id { get; set; }
		public abstract bool Closed { get; set; }
		public abstract bool PublicVoters { get; set; }
		public abstract bool MultipleChoice { get; set; }
		public abstract bool Quiz { get; set; }
		public abstract string Question { get; set; }
		public abstract IList<PollAnswerBase> Answers { get; set; }
		public abstract int? ClosePeriod { get; set; }
		public abstract int? CloseDate { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}