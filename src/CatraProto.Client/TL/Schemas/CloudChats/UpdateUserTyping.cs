using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserTyping : UpdateBase
	{
		public static int ConstructorId { get; } = 1548249383;
		public int UserId { get; set; }
		public SendMessageActionBase Action { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(UserId);
			writer.Write(Action);
		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Action = reader.Read<SendMessageActionBase>();
		}
	}
}