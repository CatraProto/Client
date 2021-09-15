using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordInputSettingsBase : IObject
    {
        [JsonProperty("new_algo")] public abstract PasswordKdfAlgoBase NewAlgo { get; set; }

        [JsonProperty("new_password_hash")] public abstract byte[] NewPasswordHash { get; set; }

        [JsonProperty("hint")] public abstract string Hint { get; set; }

        [JsonProperty("email")] public abstract string Email { get; set; }

        [JsonProperty("new_secure_settings")] public abstract SecureSecretSettingsBase NewSecureSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}