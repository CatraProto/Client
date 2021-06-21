using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgNewDetailedInfo : MsgDetailedInfoBase
	{
		public static int ConstructorId { get; } = -2137147681;
		public override long AnswerMsgId { get; set; }
		public override int Bytes { get; set; }
		public override int Status { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(AnswerMsgId);
			writer.Write(Bytes);
			writer.Write(Status);
		}

		public override void Deserialize(Reader reader)
		{
			AnswerMsgId = reader.Read<long>();
			Bytes = reader.Read<int>();
			Status = reader.Read<int>();
		}
	}
}