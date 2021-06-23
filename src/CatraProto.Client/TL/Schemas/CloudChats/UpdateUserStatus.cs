using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserStatus : UpdateBase
	{
		public static int ConstructorId { get; } = 469489699;
		public int UserId { get; set; }
		public UserStatusBase Status { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(UserId);
			writer.Write(Status);
		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Status = reader.Read<UserStatusBase>();
		}
	}
}