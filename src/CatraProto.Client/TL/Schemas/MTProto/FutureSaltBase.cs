using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class FutureSaltBase : IObject
    {
        public abstract int ValidSince { get; set; }
        public abstract int ValidUntil { get; set; }
        public abstract long Salt { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}