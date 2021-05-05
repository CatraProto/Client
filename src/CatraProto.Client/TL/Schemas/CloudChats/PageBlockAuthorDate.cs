using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockAuthorDate : PageBlockBase
	{


        public static int ConstructorId { get; } = -1162877472;
		public RichTextBase Author { get; set; }
		public int PublishedDate { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Author);
			writer.Write(PublishedDate);

		}

		public override void Deserialize(Reader reader)
		{
			Author = reader.Read<RichTextBase>();
			PublishedDate = reader.Read<int>();

		}
	}
}