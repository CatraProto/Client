using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionGeoProximityReached : MessageActionBase
	{


        public static int ConstructorId { get; } = -1730095465;
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase ToId { get; set; }
		public int Distance { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FromId);
			writer.Write(ToId);
			writer.Write(Distance);

		}

		public override void Deserialize(Reader reader)
		{
			FromId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			ToId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Distance = reader.Read<int>();

		}
	}
}