using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollResultsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("min")] public abstract bool Min { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("results")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase> Results { get; set; }

        [Newtonsoft.Json.JsonProperty("total_voters")]
        public abstract int? TotalVoters { get; set; }

        [Newtonsoft.Json.JsonProperty("recent_voters")]
        public abstract List<long> RecentVoters { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("solution")]
        public abstract string Solution { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("solution_entities")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> SolutionEntities { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}