using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollAnswerVotersBase : IObject
    {

[Newtonsoft.Json.JsonProperty("chosen")]
		public abstract bool Chosen { get; set; }

[Newtonsoft.Json.JsonProperty("correct")]
		public abstract bool Correct { get; set; }

[Newtonsoft.Json.JsonProperty("option")]
		public abstract byte[] Option { get; set; }

[Newtonsoft.Json.JsonProperty("voters")]
		public abstract int Voters { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
