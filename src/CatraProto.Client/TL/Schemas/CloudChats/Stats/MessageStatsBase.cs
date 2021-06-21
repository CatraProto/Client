using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class MessageStatsBase : IObject
    {
        public abstract StatsGraphBase ViewsGraph { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}