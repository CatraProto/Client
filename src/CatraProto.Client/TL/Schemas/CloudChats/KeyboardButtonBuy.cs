using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonBuy : KeyboardButtonBase
	{
		public static int ConstructorId { get; } = -1344716869;
		public override string Text { get; set; }

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
			Text = reader.Read<string>();
		}
	}
}