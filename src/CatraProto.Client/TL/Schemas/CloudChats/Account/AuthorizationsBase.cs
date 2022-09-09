using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class AuthorizationsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("authorization_ttl_days")]
        public abstract int AuthorizationTtlDays { get; set; }

        [Newtonsoft.Json.JsonProperty("authorizations")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase> AuthorizationsField { get; set; }

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