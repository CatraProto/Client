using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotCallbackAnswerBase : IObject
    {

[JsonPropertyName("alert")]
		public abstract bool Alert { get; set; }

[JsonPropertyName("has_url")]
		public abstract bool HasUrl { get; set; }

[JsonPropertyName("native_ui")]
		public abstract bool NativeUi { get; set; }

[JsonPropertyName("message")]
		public abstract string Message { get; set; }

[JsonPropertyName("url")]
		public abstract string Url { get; set; }

[JsonPropertyName("cache_time")]
		public abstract int CacheTime { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
