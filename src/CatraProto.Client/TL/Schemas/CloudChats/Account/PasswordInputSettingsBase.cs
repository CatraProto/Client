using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordInputSettingsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("new_algo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

[Newtonsoft.Json.JsonProperty("new_password_hash")]
		public abstract byte[] NewPasswordHash { get; set; }

[Newtonsoft.Json.JsonProperty("hint")]
		public abstract string Hint { get; set; }

[Newtonsoft.Json.JsonProperty("email")]
		public abstract string Email { get; set; }

[Newtonsoft.Json.JsonProperty("new_secure_settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase NewSecureSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
