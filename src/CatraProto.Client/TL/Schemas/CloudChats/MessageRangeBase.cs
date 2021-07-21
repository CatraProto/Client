using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageRangeBase : IObject
    {

[JsonPropertyName("min_id")]
		public abstract int MinId { get; set; }

[JsonPropertyName("max_id")]
		public abstract int MaxId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
