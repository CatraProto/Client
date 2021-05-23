using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetPollResults : IMethod
	{


        public static int ConstructorId { get; } = 1941660731;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollResults);
		public bool IsVector { get; init; } = false;
		public InputPeerBase Peer { get; set; }
		public int MsgId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MsgId = reader.Read<int>();

		}
	}
}