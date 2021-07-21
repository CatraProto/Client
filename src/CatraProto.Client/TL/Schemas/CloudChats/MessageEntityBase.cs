using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageEntityBase : IObject
    {

[JsonPropertyName("offset")]
		public abstract int Offset { get; set; }

[JsonPropertyName("length")]
		public abstract int Length { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
