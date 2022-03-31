using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureValueBase : IObject
    {

[Newtonsoft.Json.JsonProperty("type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase Data { get; set; }

[Newtonsoft.Json.JsonProperty("front_side")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase FrontSide { get; set; }

[Newtonsoft.Json.JsonProperty("reverse_side")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase ReverseSide { get; set; }

[Newtonsoft.Json.JsonProperty("selfie")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase Selfie { get; set; }

[Newtonsoft.Json.JsonProperty("translation")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Translation { get; set; }

[Newtonsoft.Json.JsonProperty("files")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Files { get; set; }

[Newtonsoft.Json.JsonProperty("plain_data")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase PlainData { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public abstract byte[] Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
