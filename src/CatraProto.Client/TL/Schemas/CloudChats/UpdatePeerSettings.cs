using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePeerSettings : UpdateBase
	{


        public static int ConstructorId { get; } = 1786671974;
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Settings);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>();

		}
	}
}