using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetSearchCounters : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>
	{


        public static int ConstructorId { get; } = 1932455680;

		public InputPeerBase Peer { get; set; }
		public IList<MessagesFilterBase> Filters { get; set; }

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
			Peer = reader.Read<InputPeerBase>();
			Filters = reader.ReadVector<MessagesFilterBase>();

		}
	}
}