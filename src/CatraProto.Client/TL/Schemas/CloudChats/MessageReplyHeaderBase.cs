using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageReplyHeaderBase : IObject
    {
		public abstract int ReplyToMsgId { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase ReplyToPeerId { get; set; }
		public abstract int? ReplyToTopId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
