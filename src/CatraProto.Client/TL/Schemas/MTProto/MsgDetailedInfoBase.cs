using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MsgDetailedInfoBase : IObject
    {
		public abstract long AnswerMsgId { get; set; }
		public abstract int Bytes { get; set; }
		public abstract int Status { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
