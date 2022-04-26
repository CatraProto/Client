using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageRangeBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("min_id")]
        public abstract int MinId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public abstract int MaxId { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
