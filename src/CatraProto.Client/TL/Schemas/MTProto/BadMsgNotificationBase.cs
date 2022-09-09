using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class BadMsgNotificationBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("bad_msg_id")]
        public abstract long BadMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("bad_msg_seqno")]
        public abstract int BadMsgSeqno { get; set; }

        [Newtonsoft.Json.JsonProperty("error_code")]
        public abstract int ErrorCode { get; set; }

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