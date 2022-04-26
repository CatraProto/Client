using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class MessageStatsBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("views_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ViewsGraph { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
