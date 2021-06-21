using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonUrl : KeyboardButtonBase
	{
		public static int ConstructorId { get; } = 629866245;
		public override string Text { get; set; }
		public string Url { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Url);
		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();
			Url = reader.Read<string>();
		}
	}
}