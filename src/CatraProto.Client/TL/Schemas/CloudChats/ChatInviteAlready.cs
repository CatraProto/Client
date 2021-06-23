using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteAlready : ChatInviteBase
	{
		public static int ConstructorId { get; } = 1516793212;
		public ChatBase Chat { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Chat);
		}

		public override void Deserialize(Reader reader)
		{
			Chat = reader.Read<ChatBase>();
		}
	}
}