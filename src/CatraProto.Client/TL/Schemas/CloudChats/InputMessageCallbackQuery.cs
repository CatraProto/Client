using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMessageCallbackQuery : InputMessageBase
	{
		public static int ConstructorId { get; } = -1392895362;
		public int Id { get; set; }
		public long QueryId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(QueryId);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			QueryId = reader.Read<long>();
		}
	}
}