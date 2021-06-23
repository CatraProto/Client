using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageEntityUnknown : MessageEntityBase
	{
		public static int ConstructorId { get; } = -1148011883;
		public override int Offset { get; set; }
		public override int Length { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Offset);
			writer.Write(Length);
		}

		public override void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Length = reader.Read<int>();
		}
	}
}