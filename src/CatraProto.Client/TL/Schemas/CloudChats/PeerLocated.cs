using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerLocated : PeerLocatedBase
	{


        public static int ConstructorId { get; } = -901375139;
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }
		public override int Expires { get; set; }
		public int Distance { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Expires);
			writer.Write(Distance);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Expires = reader.Read<int>();
			Distance = reader.Read<int>();

		}
	}
}