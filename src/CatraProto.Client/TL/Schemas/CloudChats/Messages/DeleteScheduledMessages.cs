using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DeleteScheduledMessages : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{


        public static int ConstructorId { get; } = 1504586518;

		public InputPeerBase Peer { get; set; }
		public IList<int> Id { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Id = reader.ReadVector<int>();

		}
	}
}