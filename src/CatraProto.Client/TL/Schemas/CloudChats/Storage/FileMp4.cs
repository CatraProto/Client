using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
	public partial class FileMp4 : FileTypeBase
	{
		public static int ConstructorId { get; } = -1278304028;

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
		}

		public override void Deserialize(Reader reader)
		{
		}
	}
}