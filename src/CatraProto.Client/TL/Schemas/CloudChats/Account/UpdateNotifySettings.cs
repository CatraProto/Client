using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdateNotifySettings : IMethod<bool>
	{


        public static int ConstructorId { get; } = -2067899501;

		public InputNotifyPeerBase Peer { get; set; }
		public InputPeerNotifySettingsBase Settings { get; set; }

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
			Peer = reader.Read<InputNotifyPeerBase>();
			Settings = reader.Read<InputPeerNotifySettingsBase>();

		}
	}
}