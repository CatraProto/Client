using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}