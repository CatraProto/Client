using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockEmbedPost : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        public static int StaticConstructorId { get => -229005301; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("webpage_id")]
		public long WebpageId { get; set; }

[Newtonsoft.Json.JsonProperty("author_photo_id")]
		public long AuthorPhotoId { get; set; }

[Newtonsoft.Json.JsonProperty("author")]
		public string Author { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("blocks")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

[Newtonsoft.Json.JsonProperty("caption")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


        #nullable enable
 public PageBlockEmbedPost (string url,long webpageId,long authorPhotoId,string author,int date,IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks,CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
{
 Url = url;
WebpageId = webpageId;
AuthorPhotoId = authorPhotoId;
Author = author;
Date = date;
Blocks = blocks;
Caption = caption;
 
}
#nullable disable
        internal PageBlockEmbedPost() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(WebpageId);
			writer.Write(AuthorPhotoId);
			writer.Write(Author);
			writer.Write(Date);
			writer.Write(Blocks);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			WebpageId = reader.Read<long>();
			AuthorPhotoId = reader.Read<long>();
			Author = reader.Read<string>();
			Date = reader.Read<int>();
			Blocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();

		}
				
		public override string ToString()
		{
		    return "pageBlockEmbedPost";
		}
	}
}