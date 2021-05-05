using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgNewDetailedInfo : IMethod<MsgDetailedInfoBase>
	{


        public static int ConstructorId { get; } = -2137147681;

		public Type Type { get; init; } = typeof(MsgNewDetailedInfo);
		public bool IsVector { get; init; } = false;
		public long AnswerMsgId { get; set; }
		public int Bytes { get; set; }
		public int Status { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(AnswerMsgId);
			writer.Write(Bytes);
			writer.Write(Status);

		}

		public void Deserialize(Reader reader)
		{
			AnswerMsgId = reader.Read<long>();
			Bytes = reader.Read<int>();
			Status = reader.Read<int>();

		}
	}
}