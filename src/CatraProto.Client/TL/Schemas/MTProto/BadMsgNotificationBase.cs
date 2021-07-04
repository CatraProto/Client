using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class BadMsgNotificationBase : IObject
    {
		public abstract long BadMsgId { get; set; }
		public abstract int BadMsgSeqno { get; set; }
		public abstract int ErrorCode { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
