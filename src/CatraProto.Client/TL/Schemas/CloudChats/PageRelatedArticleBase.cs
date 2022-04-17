using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageRelatedArticleBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("url")]
        public abstract string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("webpage_id")]
        public abstract long WebpageId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description")]
        public abstract string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("photo_id")]
        public abstract long? PhotoId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("author")]
        public abstract string Author { get; set; }

        [Newtonsoft.Json.JsonProperty("published_date")]
        public abstract int? PublishedDate { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
