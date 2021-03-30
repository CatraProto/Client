using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class GetMessagePublicForwards : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>
	{


        public static int ConstructorId { get; } = 1445996571;

		public InputChannelBase Channel { get; set; }
		public int MsgId { get; set; }
		public int OffsetRate { get; set; }
		public InputPeerBase OffsetPeer { get; set; }
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
			Channel = reader.Read<InputChannelBase>();
			MsgId = reader.Read<int>();
			OffsetRate = reader.Read<int>();
			OffsetPeer = reader.Read<InputPeerBase>();
			OffsetId = reader.Read<int>();
			Limit = reader.Read<int>();

		}
	}
}