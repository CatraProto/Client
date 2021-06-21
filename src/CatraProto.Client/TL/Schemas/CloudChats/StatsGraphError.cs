using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGraphError : StatsGraphBase
	{
		public static int ConstructorId { get; } = -1092839390;
		public string Error { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Error);
		}

		public override void Deserialize(Reader reader)
		{
			Error = reader.Read<string>();
		}
	}
}