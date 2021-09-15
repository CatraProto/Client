using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class SupportBase : IObject
    {
        [JsonProperty("phone_number")] public abstract string PhoneNumber { get; set; }

        [JsonProperty("user")] public abstract UserBase User { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}