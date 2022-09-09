using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class HistoryImportParsedBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("pm")] public abstract bool Pm { get; set; }

        [Newtonsoft.Json.JsonProperty("group")]
        public abstract bool Group { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

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