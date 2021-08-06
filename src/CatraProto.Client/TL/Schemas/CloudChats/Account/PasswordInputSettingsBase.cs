using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordInputSettingsBase : IObject
    {

[JsonPropertyName("new_algo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

[JsonPropertyName("new_password_hash")]
		public abstract byte[] NewPasswordHash { get; set; }

[JsonPropertyName("hint")]
		public abstract string Hint { get; set; }

[JsonPropertyName("email")]
		public abstract string Email { get; set; }

[JsonPropertyName("new_secure_settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase NewSecureSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
