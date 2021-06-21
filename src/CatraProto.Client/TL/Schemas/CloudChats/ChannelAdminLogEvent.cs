using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEvent : ChannelAdminLogEventBase
	{
		public static int ConstructorId { get; } = 995769920;
		public override long Id { get; set; }
		public override int Date { get; set; }
		public override int UserId { get; set; }
		public override ChannelAdminLogEventActionBase Action { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Date);
			writer.Write(UserId);
			writer.Write(Action);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Date = reader.Read<int>();
			UserId = reader.Read<int>();
			Action = reader.Read<ChannelAdminLogEventActionBase>();
		}
	}
}