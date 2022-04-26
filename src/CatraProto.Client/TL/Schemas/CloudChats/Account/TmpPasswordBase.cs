using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class TmpPasswordBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("tmp_password")]
        public abstract byte[] TmpPasswordField { get; set; }

        [Newtonsoft.Json.JsonProperty("valid_until")]
        public abstract int ValidUntil { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
