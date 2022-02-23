using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureDataBase : IObject
    {

[Newtonsoft.Json.JsonProperty("data")]
		public abstract byte[] Data { get; set; }

[Newtonsoft.Json.JsonProperty("data_hash")]
		public abstract byte[] DataHash { get; set; }

[Newtonsoft.Json.JsonProperty("secret")]
		public abstract byte[] Secret { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
