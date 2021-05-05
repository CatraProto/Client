using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetScheduledHistory : IMethod<MessagesBase>
	{


        public static int ConstructorId { get; } = -490575781;

		public Type Type { get; init; } = typeof(GetScheduledHistory);
		public bool IsVector { get; init; } = false;
		public InputPeerBase Peer { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Hash = reader.Read<int>();

		}
	}
}