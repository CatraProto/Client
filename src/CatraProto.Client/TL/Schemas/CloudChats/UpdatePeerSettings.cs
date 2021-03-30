using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePeerSettings : UpdateBase
	{


        public static int ConstructorId { get; } = 1786671974;
		public PeerBase Peer { get; set; }
		public PeerSettingsBase Settings { get; set; }

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
			Peer = reader.Read<PeerBase>();
			Settings = reader.Read<PeerSettingsBase>();

		}
	}
}