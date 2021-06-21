using System.Collections.Generic;
using CatraProto.TL;

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
			if (ConstructorId != 0) writer.Write(ConstructorId);
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