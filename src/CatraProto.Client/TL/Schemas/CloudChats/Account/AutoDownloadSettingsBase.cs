using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class AutoDownloadSettingsBase : IObject
    {
        [JsonProperty("low")] public abstract CloudChats.AutoDownloadSettingsBase Low { get; set; }

        [JsonProperty("medium")] public abstract CloudChats.AutoDownloadSettingsBase Medium { get; set; }

        [JsonProperty("high")] public abstract CloudChats.AutoDownloadSettingsBase High { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}