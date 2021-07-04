using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockEmbedPost : PageBlockBase
	{


        public static int ConstructorId { get; } = -229005301;
		public string Url { get; set; }
		public long WebpageId { get; set; }
		public long AuthorPhotoId { get; set; }
		public string Author { get; set; }
		public int Date { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }

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
			Blocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();

		}
	}
}