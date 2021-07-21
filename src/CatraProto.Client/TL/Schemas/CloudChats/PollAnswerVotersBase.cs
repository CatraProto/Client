using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollAnswerVotersBase : IObject
    {

[JsonPropertyName("chosen")]
		public abstract bool Chosen { get; set; }

[JsonPropertyName("correct")]
		public abstract bool Correct { get; set; }

[JsonPropertyName("option")]
		public abstract byte[] Option { get; set; }

[JsonPropertyName("voters")]
		public abstract int Voters { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
