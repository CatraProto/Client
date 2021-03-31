using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class RequestUrlAuth : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>
	{


        public static int ConstructorId { get; } = -482388461;

		public InputPeerBase Peer { get; set; }
		public int MsgId { get; set; }
		public int ButtonId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);
			writer.Write(ButtonId);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MsgId = reader.Read<int>();
			ButtonId = reader.Read<int>();

		}
	}
}