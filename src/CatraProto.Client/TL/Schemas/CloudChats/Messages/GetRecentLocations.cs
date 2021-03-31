using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetRecentLocations : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>
	{


        public static int ConstructorId { get; } = -1144759543;

		public InputPeerBase Peer { get; set; }
		public int Limit { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Limit);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Limit = reader.Read<int>();
			Hash = reader.Read<int>();

		}
	}
}