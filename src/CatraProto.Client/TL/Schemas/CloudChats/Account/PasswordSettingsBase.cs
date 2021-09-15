using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordSettingsBase : IObject
    {
        [JsonProperty("email")] public abstract string Email { get; set; }

        [JsonProperty("secure_settings")] public abstract SecureSecretSettingsBase SecureSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}