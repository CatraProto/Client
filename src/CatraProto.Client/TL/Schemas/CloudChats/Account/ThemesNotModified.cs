using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ThemesNotModified : ThemesBase
	{
		public static int ConstructorId { get; } = -199313886;

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