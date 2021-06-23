using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputDialogPeerFolder : InputDialogPeerBase
	{
		public static int ConstructorId { get; } = 1684014375;
		public int FolderId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(FolderId);
		}

		public override void Deserialize(Reader reader)
		{
			FolderId = reader.Read<int>();
		}
	}
}