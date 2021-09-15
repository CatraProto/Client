using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class SearchCounterBase : IObject
    {
        [JsonProperty("inexact")] public abstract bool Inexact { get; set; }

        [JsonProperty("filter")] public abstract MessagesFilterBase Filter { get; set; }

        [JsonProperty("count")] public abstract int Count { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}