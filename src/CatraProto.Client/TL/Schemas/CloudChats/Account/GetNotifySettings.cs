using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetNotifySettings : IMethod<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>
	{


        public static int ConstructorId { get; } = 313765169;

		public InputNotifyPeerBase Peer { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputNotifyPeerBase>();

		}
	}
}