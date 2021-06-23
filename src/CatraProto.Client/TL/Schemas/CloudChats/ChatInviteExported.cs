using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteExported : ExportedChatInviteBase
	{
		public static int ConstructorId { get; } = -64092740;
		public string Link { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Link);
		}

		public override void Deserialize(Reader reader)
		{
			Link = reader.Read<string>();
		}
	}
}