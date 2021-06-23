using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AffectedHistory : AffectedHistoryBase
	{
		public static int ConstructorId { get; } = -1269012015;
		public override int Pts { get; set; }
		public override int PtsCount { get; set; }
		public override int Offset { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Pts);
			writer.Write(PtsCount);
			writer.Write(Offset);
		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
			Offset = reader.Read<int>();
		}
	}
}