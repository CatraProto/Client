using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockRelatedArticles : PageBlockBase
	{


        public static int ConstructorId { get; } = 370236054;
		public RichTextBase Title { get; set; }
		public IList<PageRelatedArticleBase> Articles { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Title);
			writer.Write(Articles);

		}

		public override void Deserialize(Reader reader)
		{
			Title = reader.Read<RichTextBase>();
			Articles = reader.ReadVector<PageRelatedArticleBase>();

		}
	}
}