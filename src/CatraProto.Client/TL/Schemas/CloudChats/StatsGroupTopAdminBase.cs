using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsGroupTopAdminBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("user_id")]
        public abstract long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("deleted")]
        public abstract int Deleted { get; set; }

        [Newtonsoft.Json.JsonProperty("kicked")]
        public abstract int Kicked { get; set; }

        [Newtonsoft.Json.JsonProperty("banned")]
        public abstract int Banned { get; set; }

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