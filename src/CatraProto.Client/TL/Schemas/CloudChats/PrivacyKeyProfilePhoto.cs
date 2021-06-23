using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PrivacyKeyProfilePhoto : PrivacyKeyBase
	{
		public static int ConstructorId { get; } = -1777000467;

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