using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WebDocumentBase : IObject
    {

[JsonPropertyName("url")]
		public abstract string Url { get; set; }

[JsonPropertyName("size")]
		public abstract int Size { get; set; }

[JsonPropertyName("mime_type")]
		public abstract string MimeType { get; set; }

[JsonPropertyName("attributes")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
