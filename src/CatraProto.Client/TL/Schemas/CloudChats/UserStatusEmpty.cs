using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserStatusEmpty : UserStatusBase
	{
		public static int ConstructorId { get; } = 164646985;

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