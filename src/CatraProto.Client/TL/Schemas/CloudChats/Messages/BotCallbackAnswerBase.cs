using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotCallbackAnswerBase : IObject
    {
        [JsonProperty("alert")] public abstract bool Alert { get; set; }

        [JsonProperty("has_url")] public abstract bool HasUrl { get; set; }

        [JsonProperty("native_ui")] public abstract bool NativeUi { get; set; }

        [JsonProperty("message")] public abstract string Message { get; set; }

        [JsonProperty("url")] public abstract string Url { get; set; }

        [JsonProperty("cache_time")] public abstract int CacheTime { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}