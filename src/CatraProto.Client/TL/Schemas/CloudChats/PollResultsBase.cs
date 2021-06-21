using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollResultsBase : IObject
    {
        public abstract bool Min { get; set; }
        public abstract IList<PollAnswerVotersBase> Results { get; set; }
        public abstract int? TotalVoters { get; set; }
        public abstract IList<int> RecentVoters { get; set; }
        public abstract string Solution { get; set; }
        public abstract IList<MessageEntityBase> SolutionEntities { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}