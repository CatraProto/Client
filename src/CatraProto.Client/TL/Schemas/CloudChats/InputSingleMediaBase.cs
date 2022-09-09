using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputSingleMediaBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("media")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public abstract long RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public abstract string Message { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("entities")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

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