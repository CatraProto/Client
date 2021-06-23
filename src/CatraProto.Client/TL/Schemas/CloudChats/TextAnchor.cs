using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextAnchor : RichTextBase
	{
		public static int ConstructorId { get; } = 894777186;
		public RichTextBase Text { get; set; }
		public string Name { get; set; }

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
			writer.Write(Name);
		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<RichTextBase>();
			Name = reader.Read<string>();
		}
	}
}