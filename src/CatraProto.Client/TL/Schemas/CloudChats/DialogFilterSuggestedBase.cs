using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class DialogFilterSuggestedBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("filter")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public abstract string Description { get; set; }

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