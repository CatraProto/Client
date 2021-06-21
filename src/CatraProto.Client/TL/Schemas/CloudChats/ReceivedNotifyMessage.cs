using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReceivedNotifyMessage : ReceivedNotifyMessageBase
	{
		public static int ConstructorId { get; } = -1551583367;
		public override int Id { get; set; }
		public override int Flags { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Flags);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			Flags = reader.Read<int>();
		}
	}
}