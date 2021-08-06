using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FileHashBase : IObject
    {

[JsonPropertyName("offset")]
		public abstract int Offset { get; set; }

[JsonPropertyName("limit")]
		public abstract int Limit { get; set; }

[JsonPropertyName("hash")]
		public abstract byte[] Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
