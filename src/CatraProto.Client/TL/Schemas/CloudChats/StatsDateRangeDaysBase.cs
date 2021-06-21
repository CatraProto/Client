using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsDateRangeDaysBase : IObject
    {
        public abstract int MinDate { get; set; }
        public abstract int MaxDate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}