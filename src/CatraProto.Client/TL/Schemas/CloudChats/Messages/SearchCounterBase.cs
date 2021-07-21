using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class SearchCounterBase : IObject
    {

[JsonPropertyName("inexact")]
		public abstract bool Inexact { get; set; }

[JsonPropertyName("filter")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

[JsonPropertyName("count")]
		public abstract int Count { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
