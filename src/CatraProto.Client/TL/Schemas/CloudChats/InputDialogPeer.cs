using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputDialogPeer : InputDialogPeerBase
	{


        public static int ConstructorId { get; } = -55902537;
		public InputPeerBase Peer { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();

		}
	}
}