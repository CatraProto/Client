using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotResultsBase : IObject
    {

[JsonPropertyName("gallery")]
		public abstract bool Gallery { get; set; }

[JsonPropertyName("query_id")]
		public abstract long QueryId { get; set; }

[JsonPropertyName("next_offset")]
		public abstract string NextOffset { get; set; }

[JsonPropertyName("switch_pm")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase SwitchPm { get; set; }

[JsonPropertyName("results")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase> Results { get; set; }

[JsonPropertyName("cache_time")]
		public abstract int CacheTime { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
