using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadChannelOutbox : UpdateBase
	{
		public static int ConstructorId { get; } = 634833351;
		public int ChannelId { get; set; }
		public int MaxId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(ChannelId);
			writer.Write(MaxId);
		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			MaxId = reader.Read<int>();
		}
	}
}