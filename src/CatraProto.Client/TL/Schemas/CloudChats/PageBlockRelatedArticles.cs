using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockRelatedArticles : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        public static int StaticConstructorId { get => 370236054; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("title")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }

[JsonPropertyName("articles")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase> Articles { get; set; }

        
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
			Title = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Articles = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageRelatedArticleBase>();

		}
	}
}