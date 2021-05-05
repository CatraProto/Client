using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionGeoProximityReached : MessageActionBase
	{


        public static int ConstructorId { get; } = -1730095465;
		public PeerBase FromId { get; set; }
		public PeerBase ToId { get; set; }
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
			FromId = reader.Read<PeerBase>();
			ToId = reader.Read<PeerBase>();
			Distance = reader.Read<int>();

		}
	}
}