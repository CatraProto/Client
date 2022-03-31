using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SearchResultsCalendarPeriodBase : IObject
    {

[Newtonsoft.Json.JsonProperty("date")]
		public abstract int Date { get; set; }

[Newtonsoft.Json.JsonProperty("min_msg_id")]
		public abstract int MinMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("max_msg_id")]
		public abstract int MaxMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public abstract int Count { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
