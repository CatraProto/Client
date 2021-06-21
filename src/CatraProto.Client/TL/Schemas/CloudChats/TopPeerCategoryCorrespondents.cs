using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeerCategoryCorrespondents : TopPeerCategoryBase
	{
		public static int ConstructorId { get; } = 104314861;

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