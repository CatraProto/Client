using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollBase : IObject
    {

[JsonPropertyName("id")]
		public abstract long Id { get; set; }

[JsonPropertyName("closed")]
		public abstract bool Closed { get; set; }

[JsonPropertyName("public_voters")]
		public abstract bool PublicVoters { get; set; }

[JsonPropertyName("multiple_choice")]
		public abstract bool MultipleChoice { get; set; }

[JsonPropertyName("quiz")]
		public abstract bool Quiz { get; set; }

[JsonPropertyName("question")]
		public abstract string Question { get; set; }

[JsonPropertyName("answers")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase> Answers { get; set; }

[JsonPropertyName("close_period")]
		public abstract int? ClosePeriod { get; set; }

[JsonPropertyName("close_date")]
		public abstract int? CloseDate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
