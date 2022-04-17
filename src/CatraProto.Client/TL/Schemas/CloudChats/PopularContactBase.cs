using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PopularContactBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("client_id")]
        public abstract long ClientId { get; set; }

        [Newtonsoft.Json.JsonProperty("importers")]
        public abstract int Importers { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
