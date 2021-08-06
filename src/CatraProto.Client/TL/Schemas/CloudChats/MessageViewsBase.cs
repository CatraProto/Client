using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageViewsBase : IObject
    {

[JsonPropertyName("views")]
		public abstract int? Views { get; set; }

[JsonPropertyName("forwards")]
		public abstract int? Forwards { get; set; }

[JsonPropertyName("replies")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase Replies { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
