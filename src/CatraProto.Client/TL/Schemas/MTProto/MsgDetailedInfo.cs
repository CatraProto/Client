using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgDetailedInfo : IMethod
	{


        public static int ConstructorId { get; } = 661470918;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.MsgDetailedInfo);
		public bool IsVector { get; init; } = false;
		public long MsgId { get; set; }
		public long AnswerMsgId { get; set; }
		public int Bytes { get; set; }
		public int Status { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(AnswerMsgId);
			writer.Write(Bytes);
			writer.Write(Status);

		}

		public void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			AnswerMsgId = reader.Read<long>();
			Bytes = reader.Read<int>();
			Status = reader.Read<int>();

		}
	}
}