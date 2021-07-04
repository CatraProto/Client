using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdateNotifySettings : IMethod
	{


        public static int ConstructorId { get; } = -2067899501;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase Peer { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase>();
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettingsBase>();

		}
	}
}