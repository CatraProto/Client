using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollResultsBase : IObject
    {

[JsonPropertyName("min")]
		public abstract bool Min { get; set; }

[JsonPropertyName("results")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase> Results { get; set; }

[JsonPropertyName("total_voters")]
		public abstract int? TotalVoters { get; set; }

[JsonPropertyName("recent_voters")]
		public abstract IList<int> RecentVoters { get; set; }

[JsonPropertyName("solution")]
		public abstract string Solution { get; set; }

[JsonPropertyName("solution_entities")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> SolutionEntities { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
