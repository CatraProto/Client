using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SavedContactBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("phone")]
        public abstract string Phone { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public abstract string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public abstract string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public abstract int Date { get; set; }

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
