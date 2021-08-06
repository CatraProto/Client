using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordBase : IObject
    {

[JsonPropertyName("has_recovery")]
		public abstract bool HasRecovery { get; set; }

[JsonPropertyName("has_secure_values")]
		public abstract bool HasSecureValues { get; set; }

[JsonPropertyName("has_password")]
		public abstract bool HasPassword { get; set; }

[JsonPropertyName("current_algo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase CurrentAlgo { get; set; }

[JsonPropertyName("srp_B")]
		public abstract byte[] SrpB { get; set; }

[JsonPropertyName("srp_id")]
		public abstract long? SrpId { get; set; }

[JsonPropertyName("hint")]
		public abstract string Hint { get; set; }

[JsonPropertyName("email_unconfirmed_pattern")]
		public abstract string EmailUnconfirmedPattern { get; set; }

[JsonPropertyName("new_algo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

[JsonPropertyName("new_secure_algo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase NewSecureAlgo { get; set; }

[JsonPropertyName("secure_random")]
		public abstract byte[] SecureRandom { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
