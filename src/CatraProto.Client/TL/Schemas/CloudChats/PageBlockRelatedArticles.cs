using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockRelatedArticles : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        public static int StaticConstructorId { get => 370236054; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("title")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }

[Newtonsoft.Json.JsonProperty("articles")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase> Articles { get; set; }


        #nullable enable
 public PageBlockRelatedArticles (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase title,IList<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase> articles)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Title);
			writer.Write(Articles);

		}

		public override void Deserialize(Reader reader)
		{
			Title = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Articles = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase>();

		}
				
		public override string ToString()
		{
		    return "pageBlockRelatedArticles";
		}
	}
}