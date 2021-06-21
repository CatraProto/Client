using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class NearestDcBase : IObject
    {
        public abstract string Country { get; set; }
        public abstract int ThisDc { get; set; }
        public abstract int NearestDc_ { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}