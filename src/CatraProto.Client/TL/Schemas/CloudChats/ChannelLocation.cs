using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelLocation : ChannelLocationBase
	{


        public static int ConstructorId { get; } = 547062491;
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase GeoPoint { get; set; }
		public string Address { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(GeoPoint);
			writer.Write(Address);

		}

		public override void Deserialize(Reader reader)
		{
			GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
			Address = reader.Read<string>();

		}
	}
}