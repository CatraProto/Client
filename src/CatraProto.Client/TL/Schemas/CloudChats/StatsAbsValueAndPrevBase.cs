using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsAbsValueAndPrevBase : IObject
    {
        public abstract double Current { get; set; }
        public abstract double Previous { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}