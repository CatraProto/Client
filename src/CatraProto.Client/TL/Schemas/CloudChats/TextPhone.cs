using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextPhone : RichTextBase
	{
		public static int ConstructorId { get; } = 483104362;
		public RichTextBase Text { get; set; }
		public string Phone { get; set; }

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
			writer.Write(Phone);
		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<RichTextBase>();
			Phone = reader.Read<string>();
		}
	}
}