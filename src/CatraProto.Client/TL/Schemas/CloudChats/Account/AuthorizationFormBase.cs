using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class AuthorizationFormBase : IObject
    {
        [JsonProperty("required_types")] public abstract IList<SecureRequiredTypeBase> RequiredTypes { get; set; }

        [JsonProperty("values")] public abstract IList<SecureValueBase> Values { get; set; }

        [JsonProperty("errors")] public abstract IList<SecureValueErrorBase> Errors { get; set; }

        [JsonProperty("users")] public abstract IList<UserBase> Users { get; set; }

        [JsonProperty("privacy_policy_url")] public abstract string PrivacyPolicyUrl { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}