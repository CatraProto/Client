using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageRelatedArticleBase : IObject
    {

[Newtonsoft.Json.JsonProperty("url")]
		public abstract string Url { get; set; }

[Newtonsoft.Json.JsonProperty("webpage_id")]
		public abstract long WebpageId { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public abstract string Title { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public abstract string Description { get; set; }

[Newtonsoft.Json.JsonProperty("photo_id")]
		public abstract long? PhotoId { get; set; }

[Newtonsoft.Json.JsonProperty("author")]
		public abstract string Author { get; set; }

[Newtonsoft.Json.JsonProperty("published_date")]
		public abstract int? PublishedDate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
