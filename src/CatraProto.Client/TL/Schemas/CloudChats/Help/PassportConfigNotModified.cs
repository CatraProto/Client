using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class PassportConfigNotModified : PassportConfigBase
	{
		public static int ConstructorId { get; } = -1078332329;

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