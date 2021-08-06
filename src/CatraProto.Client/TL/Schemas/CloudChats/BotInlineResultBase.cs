using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class BotInlineResultBase : IObject
    {

[JsonPropertyName("id")]
		public abstract string Id { get; set; }

[JsonPropertyName("type")]
		public abstract string Type { get; set; }

[JsonPropertyName("title")]
		public abstract string Title { get; set; }

[JsonPropertyName("description")]
		public abstract string Description { get; set; }

[JsonPropertyName("send_message")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase SendMessage { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
