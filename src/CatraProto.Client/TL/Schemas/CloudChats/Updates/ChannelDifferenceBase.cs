using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public abstract class ChannelDifferenceBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("final")]
        public abstract bool Final { get; set; }

        [Newtonsoft.Json.JsonProperty("timeout")]
        public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
