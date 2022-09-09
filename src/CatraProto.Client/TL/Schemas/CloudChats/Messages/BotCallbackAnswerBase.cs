using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotCallbackAnswerBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("alert")]
        public abstract bool Alert { get; set; }

        [Newtonsoft.Json.JsonProperty("has_url")]
        public abstract bool HasUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("native_ui")]
        public abstract bool NativeUi { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("message")]
        public abstract string Message { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public abstract string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("cache_time")]
        public abstract int CacheTime { get; set; }

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