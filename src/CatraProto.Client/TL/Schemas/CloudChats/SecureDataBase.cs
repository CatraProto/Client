using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureDataBase : IObject
    {

[JsonPropertyName("data")]
		public abstract byte[] Data { get; set; }

[JsonPropertyName("data_hash")]
		public abstract byte[] DataHash { get; set; }

[JsonPropertyName("secret")]
		public abstract byte[] Secret { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
