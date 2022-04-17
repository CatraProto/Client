using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("closed")]
        public abstract bool Closed { get; set; }

        [Newtonsoft.Json.JsonProperty("public_voters")]
        public abstract bool PublicVoters { get; set; }

        [Newtonsoft.Json.JsonProperty("multiple_choice")]
        public abstract bool MultipleChoice { get; set; }

        [Newtonsoft.Json.JsonProperty("quiz")]
        public abstract bool Quiz { get; set; }

        [Newtonsoft.Json.JsonProperty("question")]
        public abstract string Question { get; set; }

        [Newtonsoft.Json.JsonProperty("answers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase> Answers { get; set; }

        [Newtonsoft.Json.JsonProperty("close_period")]
        public abstract int? ClosePeriod { get; set; }

        [Newtonsoft.Json.JsonProperty("close_date")]
        public abstract int? CloseDate { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
