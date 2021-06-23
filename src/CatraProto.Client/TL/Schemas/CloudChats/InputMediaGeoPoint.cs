using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaGeoPoint : InputMediaBase
	{
		public static int ConstructorId { get; } = -104578748;
		public InputGeoPointBase GeoPoint { get; set; }

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
		}

		public override void Deserialize(Reader reader)
		{
			GeoPoint = reader.Read<InputGeoPointBase>();
		}
	}
}