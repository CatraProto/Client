using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordBase : IObject
    {
        [JsonProperty("has_recovery")] public abstract bool HasRecovery { get; set; }

        [JsonProperty("has_secure_values")] public abstract bool HasSecureValues { get; set; }

        [JsonProperty("has_password")] public abstract bool HasPassword { get; set; }

        [JsonProperty("current_algo")] public abstract PasswordKdfAlgoBase CurrentAlgo { get; set; }

        [JsonProperty("srp_B")] public abstract byte[] SrpB { get; set; }

        [JsonProperty("srp_id")] public abstract long? SrpId { get; set; }

        [JsonProperty("hint")] public abstract string Hint { get; set; }

        [JsonProperty("email_unconfirmed_pattern")]
        public abstract string EmailUnconfirmedPattern { get; set; }

        [JsonProperty("new_algo")] public abstract PasswordKdfAlgoBase NewAlgo { get; set; }

        [JsonProperty("new_secure_algo")] public abstract SecurePasswordKdfAlgoBase NewSecureAlgo { get; set; }

        [JsonProperty("secure_random")] public abstract byte[] SecureRandom { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}