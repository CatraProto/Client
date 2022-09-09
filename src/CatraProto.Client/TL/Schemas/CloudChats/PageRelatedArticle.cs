using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageRelatedArticle : CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Title = 1 << 0,
            Description = 1 << 1,
            PhotoId = 1 << 2,
            Author = 1 << 3,
            PublishedDate = 1 << 4
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1282352120; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("webpage_id")]
        public sealed override long WebpageId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("photo_id")]
        public sealed override long? PhotoId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("author")]
        public sealed override string Author { get; set; }

        [Newtonsoft.Json.JsonProperty("published_date")]
        public sealed override int? PublishedDate { get; set; }


#nullable enable
        public PageRelatedArticle(string url, long webpageId)
        {
            Url = url;
            WebpageId = webpageId;
        }
#nullable disable
        internal PageRelatedArticle()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = PhotoId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Author == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = PublishedDate == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Url);
            writer.WriteInt64(WebpageId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Description);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt64(PhotoId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(Author);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(PublishedDate.Value);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            var trywebpageId = reader.ReadInt64();
            if (trywebpageId.IsError)
            {
                return ReadResult<IObject>.Move(trywebpageId);
            }

            WebpageId = trywebpageId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trydescription = reader.ReadString();
                if (trydescription.IsError)
                {
                    return ReadResult<IObject>.Move(trydescription);
                }

                Description = trydescription.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryphotoId = reader.ReadInt64();
                if (tryphotoId.IsError)
                {
                    return ReadResult<IObject>.Move(tryphotoId);
                }

                PhotoId = tryphotoId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryauthor = reader.ReadString();
                if (tryauthor.IsError)
                {
                    return ReadResult<IObject>.Move(tryauthor);
                }

                Author = tryauthor.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trypublishedDate = reader.ReadInt32();
                if (trypublishedDate.IsError)
                {
                    return ReadResult<IObject>.Move(trypublishedDate);
                }

                PublishedDate = trypublishedDate.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageRelatedArticle";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageRelatedArticle();
            newClonedObject.Flags = Flags;
            newClonedObject.Url = Url;
            newClonedObject.WebpageId = WebpageId;
            newClonedObject.Title = Title;
            newClonedObject.Description = Description;
            newClonedObject.PhotoId = PhotoId;
            newClonedObject.Author = Author;
            newClonedObject.PublishedDate = PublishedDate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageRelatedArticle castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (WebpageId != castedOther.WebpageId)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Description != castedOther.Description)
            {
                return true;
            }

            if (PhotoId != castedOther.PhotoId)
            {
                return true;
            }

            if (Author != castedOther.Author)
            {
                return true;
            }

            if (PublishedDate != castedOther.PublishedDate)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}