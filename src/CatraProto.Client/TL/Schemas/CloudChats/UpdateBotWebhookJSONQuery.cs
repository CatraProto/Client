using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotWebhookJSONQuery : UpdateBase
	{
		public static int ConstructorId { get; } = -1684914010;
		public long QueryId { get; set; }
		public DataJSONBase Data { get; set; }
		public int Timeout { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(QueryId);
			writer.Write(Data);
			writer.Write(Timeout);
		}

		public override void Deserialize(Reader reader)
		{
			QueryId = reader.Read<long>();
			Data = reader.Read<DataJSONBase>();
			Timeout = reader.Read<int>();
		}
	}
}