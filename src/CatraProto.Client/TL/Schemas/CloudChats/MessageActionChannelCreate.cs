using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChannelCreate : MessageActionBase
	{
		public static int ConstructorId { get; } = -1781355374;
		public string Title { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Title);
		}

		public override void Deserialize(Reader reader)
		{
			Title = reader.Read<string>();
		}
	}
}