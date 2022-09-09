using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GroupCallStreamChannelBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("channel")]
        public abstract int Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("scale")]
        public abstract int Scale { get; set; }

        [Newtonsoft.Json.JsonProperty("last_timestamp_ms")]
        public abstract long LastTimestampMs { get; set; }

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