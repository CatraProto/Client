using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockSubtitle : PageBlockBase
	{
		public static int ConstructorId { get; } = -1879401953;
		public RichTextBase Text { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Text);
		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<RichTextBase>();
		}
	}
}