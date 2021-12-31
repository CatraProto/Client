using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordBase : IObject
    {

[Newtonsoft.Json.JsonProperty("has_recovery")]
		public abstract bool HasRecovery { get; set; }

[Newtonsoft.Json.JsonProperty("has_secure_values")]
		public abstract bool HasSecureValues { get; set; }

[Newtonsoft.Json.JsonProperty("has_password")]
		public abstract bool HasPassword { get; set; }

[Newtonsoft.Json.JsonProperty("current_algo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase CurrentAlgo { get; set; }

[Newtonsoft.Json.JsonProperty("srp_B")]
		public abstract byte[] SrpB { get; set; }

[Newtonsoft.Json.JsonProperty("srp_id")]
		public abstract long? SrpId { get; set; }

[Newtonsoft.Json.JsonProperty("hint")]
		public abstract string Hint { get; set; }

[Newtonsoft.Json.JsonProperty("email_unconfirmed_pattern")]
		public abstract string EmailUnconfirmedPattern { get; set; }

[Newtonsoft.Json.JsonProperty("new_algo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

[Newtonsoft.Json.JsonProperty("new_secure_algo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase NewSecureAlgo { get; set; }

[Newtonsoft.Json.JsonProperty("secure_random")]
		public abstract byte[] SecureRandom { get; set; }

[Newtonsoft.Json.JsonProperty("pending_reset_date")]
		public abstract int? PendingResetDate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
