using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
	public partial class FileGif : FileTypeBase
	{
		public static int ConstructorId { get; } = -891180321;

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}
		}

		public override void Deserialize(Reader reader)
		{
		}
	}
}