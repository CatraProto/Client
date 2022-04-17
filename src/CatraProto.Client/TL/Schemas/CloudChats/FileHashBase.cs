using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FileHashBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("offset")]
        public abstract int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public abstract int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public abstract byte[] Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
