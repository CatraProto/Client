using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class SupportBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public abstract string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("user")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
