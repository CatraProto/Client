using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotResultsBase : IObject
    {
        [JsonProperty("gallery")] public abstract bool Gallery { get; set; }

        [JsonProperty("query_id")] public abstract long QueryId { get; set; }

        [JsonProperty("next_offset")] public abstract string NextOffset { get; set; }

        [JsonProperty("switch_pm")] public abstract InlineBotSwitchPMBase SwitchPm { get; set; }

        [JsonProperty("results")] public abstract IList<BotInlineResultBase> Results { get; set; }

        [JsonProperty("cache_time")] public abstract int CacheTime { get; set; }

        [JsonProperty("users")] public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}