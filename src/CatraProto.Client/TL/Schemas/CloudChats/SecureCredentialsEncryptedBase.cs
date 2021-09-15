using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureCredentialsEncryptedBase : IObject
    {

[Newtonsoft.Json.JsonProperty("data")]
		public abstract byte[] Data { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public abstract byte[] Hash { get; set; }

[Newtonsoft.Json.JsonProperty("secret")]
		public abstract byte[] Secret { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
