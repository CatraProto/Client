using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class ContentSettingsBase : IObject
    {
        [JsonProperty("sensitive_enabled")] public abstract bool SensitiveEnabled { get; set; }

        [JsonProperty("sensitive_can_change")] public abstract bool SensitiveCanChange { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}