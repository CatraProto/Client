using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDraftMessage : UpdateBase
	{


        public static int ConstructorId { get; } = -299124375;
		public PeerBase Peer { get; set; }
		public DraftMessageBase Draft { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Draft);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<PeerBase>();
			Draft = reader.Read<DraftMessageBase>();

		}
	}
}