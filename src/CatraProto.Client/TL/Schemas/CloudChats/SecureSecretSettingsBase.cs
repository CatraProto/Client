using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureSecretSettingsBase : IObject
    {

[JsonPropertyName("secure_algo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase SecureAlgo { get; set; }

[JsonPropertyName("secure_secret")]
		public abstract byte[] SecureSecret { get; set; }

[JsonPropertyName("secure_secret_id")]
		public abstract long SecureSecretId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
