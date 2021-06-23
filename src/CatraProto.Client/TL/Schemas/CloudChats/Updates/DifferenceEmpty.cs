using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class DifferenceEmpty : DifferenceBase
	{
		public static int ConstructorId { get; } = 1567990072;
		public int Date { get; set; }
		public int Seq { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Date);
			writer.Write(Seq);
		}

		public override void Deserialize(Reader reader)
		{
			Date = reader.Read<int>();
			Seq = reader.Read<int>();
		}
	}
}