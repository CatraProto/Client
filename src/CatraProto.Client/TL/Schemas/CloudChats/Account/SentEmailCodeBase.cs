using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class SentEmailCodeBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("email_pattern")]
        public abstract string EmailPattern { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public abstract int Length { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
