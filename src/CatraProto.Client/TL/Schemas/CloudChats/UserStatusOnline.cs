using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserStatusOnline : UserStatusBase
	{
		public static int ConstructorId { get; } = -306628279;
		public int Expires { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Expires);
		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();
		}
	}
}