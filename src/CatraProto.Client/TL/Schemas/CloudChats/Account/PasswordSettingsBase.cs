using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordSettingsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("email")]
		public abstract string Email { get; set; }

[Newtonsoft.Json.JsonProperty("secure_settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase SecureSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
