using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetMessageEditData : IMethod
	{


        public static int ConstructorId { get; } = -39416522;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }
		public int Id { get; set; }

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
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Id = reader.Read<int>();

		}
	}
}