using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureValueBase : IObject
    {

[JsonPropertyName("type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[JsonPropertyName("data")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase Data { get; set; }

[JsonPropertyName("front_side")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase FrontSide { get; set; }

[JsonPropertyName("reverse_side")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase ReverseSide { get; set; }

[JsonPropertyName("selfie")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase Selfie { get; set; }

[JsonPropertyName("translation")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Translation { get; set; }

[JsonPropertyName("files")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Files { get; set; }

[JsonPropertyName("plain_data")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase PlainData { get; set; }

[JsonPropertyName("hash")]
		public abstract byte[] Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
