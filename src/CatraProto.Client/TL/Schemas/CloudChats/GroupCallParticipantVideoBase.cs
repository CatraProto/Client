using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GroupCallParticipantVideoBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("paused")]
        public abstract bool Paused { get; set; }

        [Newtonsoft.Json.JsonProperty("endpoint")]
        public abstract string Endpoint { get; set; }

        [Newtonsoft.Json.JsonProperty("source_groups")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase> SourceGroups { get; set; }

        [Newtonsoft.Json.JsonProperty("audio_source")]
        public abstract int? AudioSource { get; set; }

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