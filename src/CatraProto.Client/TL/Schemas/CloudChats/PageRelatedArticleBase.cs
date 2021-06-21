using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageRelatedArticleBase : IObject
    {
        public abstract string Url { get; set; }
        public abstract long WebpageId { get; set; }
        public abstract string Title { get; set; }
        public abstract string Description { get; set; }
        public abstract long? PhotoId { get; set; }
        public abstract string Author { get; set; }
        public abstract int? PublishedDate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}