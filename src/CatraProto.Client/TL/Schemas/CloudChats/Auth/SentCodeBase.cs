using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class SentCodeBase : IObject
    {

[Newtonsoft.Json.JsonProperty("type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("phone_code_hash")]
		public abstract string PhoneCodeHash { get; set; }

[Newtonsoft.Json.JsonProperty("next_type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase NextType { get; set; }

[Newtonsoft.Json.JsonProperty("timeout")]
		public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
