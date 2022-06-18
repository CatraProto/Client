using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureCredentialsEncryptedBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("data")]
        public abstract byte[] Data { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public abstract byte[] Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public abstract byte[] Secret { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}
