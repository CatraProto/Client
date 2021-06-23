using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteEmpty : ExportedChatInviteBase
	{
		public static int ConstructorId { get; } = 1776236393;

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}
		}

		public override void Deserialize(Reader reader)
		{
		}
	}
}