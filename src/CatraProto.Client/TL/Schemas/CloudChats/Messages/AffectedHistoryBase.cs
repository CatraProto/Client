using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class AffectedHistoryBase : IObject
    {
        [JsonProperty("pts")] public abstract int Pts { get; set; }

        [JsonProperty("pts_count")] public abstract int PtsCount { get; set; }

        [JsonProperty("offset")] public abstract int Offset { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}