using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class AuthorizationFormBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("required_types")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> RequiredTypes { get; set; }

        [Newtonsoft.Json.JsonProperty("values")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }

        [Newtonsoft.Json.JsonProperty("errors")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> Errors { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("privacy_policy_url")]
        public abstract string PrivacyPolicyUrl { get; set; }

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