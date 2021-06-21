using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNotifySettings : UpdateBase
	{


        public static int ConstructorId { get; } = -1094555409;
		public CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase Peer { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(NotifySettings);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase>();
			NotifySettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();

		}
	}
}