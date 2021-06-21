using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChatDefaultBannedRights : UpdateBase
	{


        public static int ConstructorId { get; } = 1421875280;
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase DefaultBannedRights { get; set; }
		public int Version { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(DefaultBannedRights);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			DefaultBannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
			Version = reader.Read<int>();

		}
	}
}