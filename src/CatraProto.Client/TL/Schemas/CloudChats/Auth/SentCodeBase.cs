using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class SentCodeBase : IObject
    {

[JsonPropertyName("type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase Type { get; set; }

[JsonPropertyName("phone_code_hash")]
		public abstract string PhoneCodeHash { get; set; }

[JsonPropertyName("next_type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase NextType { get; set; }

[JsonPropertyName("timeout")]
		public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
