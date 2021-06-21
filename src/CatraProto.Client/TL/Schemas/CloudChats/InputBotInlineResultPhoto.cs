using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineResultPhoto : InputBotInlineResultBase
	{
		public static int ConstructorId { get; } = -1462213465;
		public override string Id { get; set; }
		public string Type { get; set; }
		public InputPhotoBase Photo { get; set; }
		public override InputBotInlineMessageBase SendMessage { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Type);
			writer.Write(Photo);
			writer.Write(SendMessage);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			Type = reader.Read<string>();
			Photo = reader.Read<InputPhotoBase>();
			SendMessage = reader.Read<InputBotInlineMessageBase>();
		}
	}
}