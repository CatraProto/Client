using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureCredentialsEncryptedBase : IObject
    {

[JsonPropertyName("data")]
		public abstract byte[] Data { get; set; }

[JsonPropertyName("hash")]
		public abstract byte[] Hash { get; set; }

[JsonPropertyName("secret")]
		public abstract byte[] Secret { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
