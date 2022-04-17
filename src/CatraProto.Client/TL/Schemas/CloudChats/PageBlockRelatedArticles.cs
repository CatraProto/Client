using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockRelatedArticles : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 370236054; }

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
    }
}