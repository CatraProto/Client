using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class NearestDcBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("country")]
        public abstract string Country { get; set; }

        [Newtonsoft.Json.JsonProperty("this_dc")]
        public abstract int ThisDc { get; set; }

        [Newtonsoft.Json.JsonProperty("nearest_dc")]
        public abstract int NearestDcField { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
