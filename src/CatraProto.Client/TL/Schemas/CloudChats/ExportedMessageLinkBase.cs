using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ExportedMessageLinkBase : IObject
    {

[JsonPropertyName("link")]
		public abstract string Link { get; set; }

[JsonPropertyName("html")]
		public abstract string Html { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
