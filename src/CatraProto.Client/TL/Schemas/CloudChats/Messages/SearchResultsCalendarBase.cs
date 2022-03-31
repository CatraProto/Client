using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class SearchResultsCalendarBase : IObject
    {

[Newtonsoft.Json.JsonProperty("inexact")]
		public abstract bool Inexact { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public abstract int Count { get; set; }

[Newtonsoft.Json.JsonProperty("min_date")]
		public abstract int MinDate { get; set; }

[Newtonsoft.Json.JsonProperty("min_msg_id")]
		public abstract int MinMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("offset_id_offset")]
		public abstract int? OffsetIdOffset { get; set; }

[Newtonsoft.Json.JsonProperty("periods")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase> Periods { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
