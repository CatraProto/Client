using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerChannelFromMessage : InputPeerBase
	{


        public static int ConstructorId { get; } = -1667893317;
		public InputPeerBase Peer { get; set; }
		public int MsgId { get; set; }
		public int ChannelId { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);
			writer.Write(ChannelId);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MsgId = reader.Read<int>();
			ChannelId = reader.Read<int>();

		}
	}
}