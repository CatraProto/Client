using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputWebFileGeoPointLocation : InputWebFileLocationBase
	{
		public static int ConstructorId { get; } = -1625153079;
		public InputGeoPointBase GeoPoint { get; set; }
		public override long AccessHash { get; set; }
		public int W { get; set; }
		public int H { get; set; }
		public int Zoom { get; set; }
		public int Scale { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(GeoPoint);
			writer.Write(AccessHash);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Zoom);
			writer.Write(Scale);
		}

		public override void Deserialize(Reader reader)
		{
			GeoPoint = reader.Read<InputGeoPointBase>();
			AccessHash = reader.Read<long>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Zoom = reader.Read<int>();
			Scale = reader.Read<int>();
		}
	}
}