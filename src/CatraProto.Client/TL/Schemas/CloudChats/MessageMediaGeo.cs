using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaGeo : MessageMediaBase
	{


        public static int ConstructorId { get; } = 1457575028;
		public GeoPointBase Geo { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Geo);

		}

		public override void Deserialize(Reader reader)
		{
			Geo = reader.Read<GeoPointBase>();

		}
	}
}