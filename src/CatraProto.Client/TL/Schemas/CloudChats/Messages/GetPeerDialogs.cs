using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetPeerDialogs : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>
	{


        public static int ConstructorId { get; } = -462373635;

		public IList<InputDialogPeerBase> Peers { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peers);

		}

		public void Deserialize(Reader reader)
		{
			Peers = reader.ReadVector<InputDialogPeerBase>();

		}
	}
}