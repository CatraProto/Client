using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MessageBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("msg_id")]
        public abstract long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("seqno")]
        public abstract int Seqno { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public abstract int Bytes { get; set; }

        [Newtonsoft.Json.JsonProperty("body")] public abstract IObject Body { get; set; }

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