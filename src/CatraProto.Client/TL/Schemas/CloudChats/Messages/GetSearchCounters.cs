using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetSearchCounters : IMethod
	{


        public static int ConstructorId { get; } = 1932455680;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase> Filters { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Filters);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Filters = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();

		}
	}
}