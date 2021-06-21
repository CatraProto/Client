using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MessageBase : IObject
    {
        public abstract long MsgId { get; set; }
        public abstract int Seqno { get; set; }
        public abstract int Bytes { get; set; }
        public abstract IObject Body { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}