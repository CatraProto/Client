using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Pong : PongBase
	{
		public static int ConstructorId { get; } = 880243653;
		public override long MsgId { get; set; }
		public override long PingId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(PingId);
		}

		public override void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			PingId = reader.Read<long>();
		}
	}
}