using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class BadMsgNotification : BadMsgNotificationBase
	{
		public static int ConstructorId { get; } = -1477445615;
		public override long BadMsgId { get; set; }
		public override int BadMsgSeqno { get; set; }
		public override int ErrorCode { get; set; }

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
		}

		public override void Deserialize(Reader reader)
		{
			BadMsgId = reader.Read<long>();
			BadMsgSeqno = reader.Read<int>();
			ErrorCode = reader.Read<int>();
		}
	}
}