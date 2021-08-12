using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockRelatedArticles : PageBlockBase
	{


        public static int StaticConstructorId { get => 370236054; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("title")]
		public RichTextBase Title { get; set; }

[JsonPropertyName("articles")]
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

		public override string ToString()
		{
			return "pageBlockRelatedArticles";
		}
	}
}