using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordSettingsBase : IObject
    {

[JsonPropertyName("email")]
		public abstract string Email { get; set; }

[JsonPropertyName("secure_settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase SecureSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
