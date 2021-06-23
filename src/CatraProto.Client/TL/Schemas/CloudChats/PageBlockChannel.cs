using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockChannel : PageBlockBase
	{
		public static int ConstructorId { get; } = -283684427;
		public ChatBase Channel { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Channel);
		}

		public override void Deserialize(Reader reader)
		{
			Channel = reader.Read<ChatBase>();
		}
	}
}