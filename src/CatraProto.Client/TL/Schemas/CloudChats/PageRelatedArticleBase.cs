using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageRelatedArticleBase : IObject
    {

[JsonPropertyName("url")]
		public abstract string Url { get; set; }

[JsonPropertyName("webpage_id")]
		public abstract long WebpageId { get; set; }

[JsonPropertyName("title")]
		public abstract string Title { get; set; }

[JsonPropertyName("description")]
		public abstract string Description { get; set; }

[JsonPropertyName("photo_id")]
		public abstract long? PhotoId { get; set; }

[JsonPropertyName("author")]
		public abstract string Author { get; set; }

[JsonPropertyName("published_date")]
		public abstract int? PublishedDate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
