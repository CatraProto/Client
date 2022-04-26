using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputAppEventBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("time")]
        public abstract double Time { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public abstract string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public abstract long Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("data")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Data { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
