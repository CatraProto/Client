using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class SentCodeBase : IObject
    {
        [JsonProperty("type")] public abstract SentCodeTypeBase Type { get; set; }

        [JsonProperty("phone_code_hash")] public abstract string PhoneCodeHash { get; set; }

        [JsonProperty("next_type")] public abstract CodeTypeBase NextType { get; set; }

        [JsonProperty("timeout")] public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}