using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageInteractionCountersBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("msg_id")]
        public abstract int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("views")]
        public abstract int Views { get; set; }

        [Newtonsoft.Json.JsonProperty("forwards")]
        public abstract int Forwards { get; set; }

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