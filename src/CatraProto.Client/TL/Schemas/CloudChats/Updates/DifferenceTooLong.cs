using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class DifferenceTooLong : DifferenceBase
	{
		public static int ConstructorId { get; } = 1258196845;
		public int Pts { get; set; }

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
		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();
		}
	}
}