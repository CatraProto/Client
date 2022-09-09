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
    public partial class PageBlockRelatedArticles : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 370236054; }

        [Newtonsoft.Json.JsonProperty("title")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }

        [Newtonsoft.Json.JsonProperty("articles")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase> Articles { get; set; }


#nullable enable
        public PageBlockRelatedArticles(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase title, List<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase> articles)
        {
            Title = title;
            Articles = articles;
        }
#nullable disable
        internal PageBlockRelatedArticles()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktitle = writer.WriteObject(Title);
            if (checktitle.IsError)
            {
                return checktitle;
            }

            var checkarticles = writer.WriteVector(Articles, false);
            if (checkarticles.IsError)
            {
                return checkarticles;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytitle = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            var tryarticles = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryarticles.IsError)
            {
                return ReadResult<IObject>.Move(tryarticles);
            }

            Articles = tryarticles.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageBlockRelatedArticles";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockRelatedArticles();
            var cloneTitle = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Title.Clone();
            if (cloneTitle is null)
            {
                return null;
            }

            newClonedObject.Title = cloneTitle;
            newClonedObject.Articles = new List<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase>();
            foreach (var articles in Articles)
            {
                var clonearticles = (CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase?)articles.Clone();
                if (clonearticles is null)
                {
                    return null;
                }

                newClonedObject.Articles.Add(clonearticles);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockRelatedArticles castedOther)
            {
                return true;
            }

            if (Title.Compare(castedOther.Title))
            {
                return true;
            }

            var articlessize = castedOther.Articles.Count;
            if (articlessize != Articles.Count)
            {
                return true;
            }

            for (var i = 0; i < articlessize; i++)
            {
                if (castedOther.Articles[i].Compare(Articles[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}