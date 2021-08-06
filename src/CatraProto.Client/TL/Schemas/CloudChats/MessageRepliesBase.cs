using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageRepliesBase : IObject
    {

[JsonPropertyName("comments")]
		public abstract bool Comments { get; set; }

[JsonPropertyName("replies")]
		public abstract int Replies { get; set; }

[JsonPropertyName("replies_pts")]
		public abstract int RepliesPts { get; set; }

[JsonPropertyName("recent_repliers")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> RecentRepliers { get; set; }

[JsonPropertyName("channel_id")]
		public abstract int? ChannelId { get; set; }

[JsonPropertyName("max_id")]
		public abstract int? MaxId { get; set; }

[JsonPropertyName("read_max_id")]
		public abstract int? ReadMaxId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
