using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageReplyHeaderBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
        public abstract int ReplyToMsgId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reply_to_peer_id")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase ReplyToPeerId { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_top_id")]
        public abstract int? ReplyToTopId { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
