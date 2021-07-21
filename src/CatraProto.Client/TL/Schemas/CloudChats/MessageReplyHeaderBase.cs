using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageReplyHeaderBase : IObject
    {

[JsonPropertyName("reply_to_msg_id")]
		public abstract int ReplyToMsgId { get; set; }

[JsonPropertyName("reply_to_peer_id")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase ReplyToPeerId { get; set; }

[JsonPropertyName("reply_to_top_id")]
		public abstract int? ReplyToTopId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
