using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public abstract class ChannelDifferenceBase : IObject
    {
        public abstract bool Final { get; set; }
        public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}