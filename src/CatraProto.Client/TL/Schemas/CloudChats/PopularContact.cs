using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PopularContact : PopularContactBase
	{
		public static int ConstructorId { get; } = 1558266229;
		public override long ClientId { get; set; }
		public override int Importers { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(ClientId);
			writer.Write(Importers);
		}

		public override void Deserialize(Reader reader)
		{
			ClientId = reader.Read<long>();
			Importers = reader.Read<int>();
		}
	}
}