using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputChannelFromMessage : InputChannelBase
	{
		public static int ConstructorId { get; } = 707290417;
		public InputPeerBase Peer { get; set; }
		public int MsgId { get; set; }
		public int ChannelId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
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