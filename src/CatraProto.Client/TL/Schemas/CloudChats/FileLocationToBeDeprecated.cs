using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class FileLocationToBeDeprecated : FileLocationBase
	{
		public static int ConstructorId { get; } = -1132476723;
		public override long VolumeId { get; set; }
		public override int LocalId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(VolumeId);
			writer.Write(LocalId);
		}

		public override void Deserialize(Reader reader)
		{
			VolumeId = reader.Read<long>();
			LocalId = reader.Read<int>();
		}
	}
}