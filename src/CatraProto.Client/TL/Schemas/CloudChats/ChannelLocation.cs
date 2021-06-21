using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelLocation : ChannelLocationBase
	{
		public static int ConstructorId { get; } = 547062491;
		public GeoPointBase GeoPoint { get; set; }
		public string Address { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(GeoPoint);
			writer.Write(Address);
		}

		public override void Deserialize(Reader reader)
		{
			GeoPoint = reader.Read<GeoPointBase>();
			Address = reader.Read<string>();
		}
	}
}