using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetOnlines : IMethod
	{


        public static int ConstructorId { get; } = 1848369232;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.GetOnlines);
		public bool IsVector { get; init; } = false;
		public InputPeerBase Peer { get; set; }

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
			Peer = reader.Read<InputPeerBase>();

		}
	}
}