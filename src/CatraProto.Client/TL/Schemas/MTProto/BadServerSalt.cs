using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class BadServerSalt : BadMsgNotificationBase
	{
		public static int ConstructorId { get; } = -307542917;
		public override long BadMsgId { get; set; }
		public override int BadMsgSeqno { get; set; }
		public override int ErrorCode { get; set; }
		public long NewServerSalt { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(BadMsgId);
			writer.Write(BadMsgSeqno);
			writer.Write(ErrorCode);
			writer.Write(NewServerSalt);
		}

		public override void Deserialize(Reader reader)
		{
			BadMsgId = reader.Read<long>();
			BadMsgSeqno = reader.Read<int>();
			ErrorCode = reader.Read<int>();
			NewServerSalt = reader.Read<long>();
		}
	}
}