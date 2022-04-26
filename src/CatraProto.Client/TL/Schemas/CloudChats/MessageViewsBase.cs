using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageViewsBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("views")]
        public abstract int? Views { get; set; }

        [Newtonsoft.Json.JsonProperty("forwards")]
        public abstract int? Forwards { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("replies")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase Replies { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
