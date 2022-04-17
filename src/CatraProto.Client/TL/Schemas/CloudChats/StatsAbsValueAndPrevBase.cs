using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsAbsValueAndPrevBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("current")]
        public abstract double Current { get; set; }

        [Newtonsoft.Json.JsonProperty("previous")]
        public abstract double Previous { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
