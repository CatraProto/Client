using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class AuthorizationFormBase : IObject
    {

[Newtonsoft.Json.JsonProperty("required_types")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> RequiredTypes { get; set; }

[Newtonsoft.Json.JsonProperty("values")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }

[Newtonsoft.Json.JsonProperty("errors")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> Errors { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("privacy_policy_url")]
		public abstract string PrivacyPolicyUrl { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
