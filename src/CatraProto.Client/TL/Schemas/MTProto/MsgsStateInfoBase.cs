using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MsgsStateInfoBase : IObject
    {
        public abstract long ReqMsgId { get; set; }
        public abstract byte[] Info { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}