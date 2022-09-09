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
    public partial class PageBlockAuthorDate : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1162877472; }

        [Newtonsoft.Json.JsonProperty("author")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Author { get; set; }

        [Newtonsoft.Json.JsonProperty("published_date")]
        public int PublishedDate { get; set; }


#nullable enable
        public PageBlockAuthorDate(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase author, int publishedDate)
        {
            Author = author;
            PublishedDate = publishedDate;
        }
#nullable disable
        internal PageBlockAuthorDate()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkauthor = writer.WriteObject(Author);
            if (checkauthor.IsError)
            {
                return checkauthor;
            }

            writer.WriteInt32(PublishedDate);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryauthor = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (tryauthor.IsError)
            {
                return ReadResult<IObject>.Move(tryauthor);
            }

            Author = tryauthor.Value;
            var trypublishedDate = reader.ReadInt32();
            if (trypublishedDate.IsError)
            {
                return ReadResult<IObject>.Move(trypublishedDate);
            }

            PublishedDate = trypublishedDate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageBlockAuthorDate";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockAuthorDate();
            var cloneAuthor = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Author.Clone();
            if (cloneAuthor is null)
            {
                return null;
            }

            newClonedObject.Author = cloneAuthor;
            newClonedObject.PublishedDate = PublishedDate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockAuthorDate castedOther)
            {
                return true;
            }

            if (Author.Compare(castedOther.Author))
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