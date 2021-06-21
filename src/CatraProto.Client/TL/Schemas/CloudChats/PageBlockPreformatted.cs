using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockPreformatted : PageBlockBase
	{
		public static int ConstructorId { get; } = -1066346178;
		public RichTextBase Text { get; set; }
		public string Language { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Language);
		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<RichTextBase>();
			Language = reader.Read<string>();
		}
	}
}