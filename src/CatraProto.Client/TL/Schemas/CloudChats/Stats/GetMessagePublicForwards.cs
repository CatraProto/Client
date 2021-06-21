using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class GetMessagePublicForwards : IMethod
	{


        public static int ConstructorId { get; } = 1445996571;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }
		public int MsgId { get; set; }
		public int OffsetRate { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase OffsetPeer { get; set; }
		public int OffsetId { get; set; }
		public int Limit { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(MsgId);
			writer.Write(OffsetRate);
			writer.Write(OffsetPeer);
			writer.Write(OffsetId);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			MsgId = reader.Read<int>();
			OffsetRate = reader.Read<int>();
			OffsetPeer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			OffsetId = reader.Read<int>();
			Limit = reader.Read<int>();

		}
	}
}