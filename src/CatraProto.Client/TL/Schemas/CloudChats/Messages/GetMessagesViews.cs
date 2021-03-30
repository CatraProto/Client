using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetMessagesViews : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase>
	{


        public static int ConstructorId { get; } = 1468322785;

		public InputPeerBase Peer { get; set; }
		public IList<int> Id { get; set; }
		public bool Increment { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Id);
			writer.Write(Increment);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Id = reader.ReadVector<int>();
			Increment = reader.Read<bool>();

		}
	}
}