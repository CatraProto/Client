using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageRepliesBase : IObject
    {

[Newtonsoft.Json.JsonProperty("comments")]
		public abstract bool Comments { get; set; }

[Newtonsoft.Json.JsonProperty("replies")]
		public abstract int Replies { get; set; }

[Newtonsoft.Json.JsonProperty("replies_pts")]
		public abstract int RepliesPts { get; set; }

[Newtonsoft.Json.JsonProperty("recent_repliers")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> RecentRepliers { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public abstract long? ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public abstract int? MaxId { get; set; }

[Newtonsoft.Json.JsonProperty("read_max_id")]
		public abstract int? ReadMaxId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
