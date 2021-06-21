using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
	public partial class FileMov : FileTypeBase
	{
		public static int ConstructorId { get; } = 1258941372;

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