using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FileHashBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("offset")]
        public abstract long Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public abstract int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public abstract byte[] Hash { get; set; }

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