using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadChannelDiscussionOutbox : UpdateBase
	{


        public static int ConstructorId { get; } = 1178116716;
		public int ChannelId { get; set; }
		public int TopMsgId { get; set; }
		public int ReadMaxId { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(TopMsgId);
			writer.Write(ReadMaxId);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			TopMsgId = reader.Read<int>();
			ReadMaxId = reader.Read<int>();

		}
	}
}