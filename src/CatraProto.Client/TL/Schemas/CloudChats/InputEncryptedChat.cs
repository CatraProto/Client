using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputEncryptedChat : InputEncryptedChatBase
	{
		public static int ConstructorId { get; } = -247351839;
		public override int ChatId { get; set; }
		public override long AccessHash { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(ChatId);
			writer.Write(AccessHash);
		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			AccessHash = reader.Read<long>();
		}
	}
}