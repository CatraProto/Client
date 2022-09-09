using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class NewSessionBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("first_msg_id")]
        public abstract long FirstMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("unique_id")]
        public abstract long UniqueId { get; set; }

        [Newtonsoft.Json.JsonProperty("server_salt")]
        public abstract long ServerSalt { get; set; }

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