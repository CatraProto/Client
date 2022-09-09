using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WebAuthorizationBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("hash")] public abstract long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public abstract long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("domain")]
        public abstract string Domain { get; set; }

        [Newtonsoft.Json.JsonProperty("browser")]
        public abstract string Browser { get; set; }

        [Newtonsoft.Json.JsonProperty("platform")]
        public abstract string Platform { get; set; }

        [Newtonsoft.Json.JsonProperty("date_created")]
        public abstract int DateCreated { get; set; }

        [Newtonsoft.Json.JsonProperty("date_active")]
        public abstract int DateActive { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")] public abstract string Ip { get; set; }

        [Newtonsoft.Json.JsonProperty("region")]
        public abstract string Region { get; set; }

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