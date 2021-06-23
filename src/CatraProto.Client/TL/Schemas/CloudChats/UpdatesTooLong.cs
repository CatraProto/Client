using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatesTooLong : UpdatesBase
	{
		public static int ConstructorId { get; } = -484987010;

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