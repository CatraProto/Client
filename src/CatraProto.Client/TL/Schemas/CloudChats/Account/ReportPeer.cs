using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ReportPeer : IMethod<bool>
	{


        public static int ConstructorId { get; } = -1374118561;

		public InputPeerBase Peer { get; set; }
		public ReportReasonBase Reason { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Reason);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Reason = reader.Read<ReportReasonBase>();

		}
	}
}