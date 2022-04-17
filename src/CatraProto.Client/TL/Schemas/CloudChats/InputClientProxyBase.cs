using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputClientProxyBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("address")]
        public abstract string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("port")]
        public abstract int Port { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
