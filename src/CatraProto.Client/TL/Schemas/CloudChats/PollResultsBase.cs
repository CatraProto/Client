using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollResultsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("min")]
		public abstract bool Min { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("total_voters")]
		public abstract int? TotalVoters { get; set; }

[Newtonsoft.Json.JsonProperty("recent_voters")]
		public abstract IList<long> RecentVoters { get; set; }

[Newtonsoft.Json.JsonProperty("solution")]
		public abstract string Solution { get; set; }

[Newtonsoft.Json.JsonProperty("solution_entities")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> SolutionEntities { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
