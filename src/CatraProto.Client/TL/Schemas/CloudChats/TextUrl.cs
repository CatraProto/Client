using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextUrl : RichTextBase
	{
		public static int ConstructorId { get; } = 1009288385;
		public RichTextBase Text { get; set; }
		public string Url { get; set; }
		public long WebpageId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Url);
			writer.Write(WebpageId);
		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<RichTextBase>();
			Url = reader.Read<string>();
			WebpageId = reader.Read<long>();
		}
	}
}