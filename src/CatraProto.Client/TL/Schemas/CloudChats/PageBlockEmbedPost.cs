using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockEmbedPost : PageBlockBase
	{


        public static int StaticConstructorId { get => -229005301; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("url")]
		public string Url { get; set; }

[JsonPropertyName("webpage_id")]
		public long WebpageId { get; set; }

[JsonPropertyName("author_photo_id")]
		public long AuthorPhotoId { get; set; }

[JsonPropertyName("author")]
		public string Author { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("blocks")]
		public IList<PageBlockBase> Blocks { get; set; }

[JsonPropertyName("caption")]
		public PageCaptionBase Caption { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
			Blocks = reader.ReadVector<PageBlockBase>();
			Caption = reader.Read<PageCaptionBase>();
		}

		public override string ToString()
		{
			return "pageBlockEmbedPost";
		}
	}
}