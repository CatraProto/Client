using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelAvailableMessages : UpdateBase
	{
		public static int ConstructorId { get; } = 1893427255;
		public int ChannelId { get; set; }
		public int AvailableMinId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(AvailableMinId);
		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			AvailableMinId = reader.Read<int>();
		}
	}
}