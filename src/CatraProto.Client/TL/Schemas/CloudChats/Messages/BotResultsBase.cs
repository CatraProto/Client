using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotResultsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("gallery")]
		public abstract bool Gallery { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public abstract long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("next_offset")]
		public abstract string NextOffset { get; set; }

[Newtonsoft.Json.JsonProperty("switch_pm")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase SwitchPm { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("cache_time")]
		public abstract int CacheTime { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
