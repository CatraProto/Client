using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class FutureSaltsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("req_msg_id")]
        public abstract long ReqMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("now")] public abstract int Now { get; set; }

        [Newtonsoft.Json.JsonProperty("salts")]
        public abstract List<CatraProto.Client.TL.Schemas.MTProto.FutureSalt> Salts { get; set; }

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