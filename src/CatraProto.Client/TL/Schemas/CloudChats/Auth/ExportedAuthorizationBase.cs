using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class ExportedAuthorizationBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public abstract byte[] Bytes { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
