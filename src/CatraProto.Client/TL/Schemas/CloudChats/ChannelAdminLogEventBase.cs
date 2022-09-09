using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChannelAdminLogEventBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("id")] public abstract long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public abstract int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public abstract long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("action")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase Action { get; set; }

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