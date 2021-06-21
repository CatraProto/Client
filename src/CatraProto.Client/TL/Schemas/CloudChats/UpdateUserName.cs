using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserName : UpdateBase
	{
		public static int ConstructorId { get; } = -1489818765;
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(FirstName);
			writer.Write(LastName);
			writer.Write(Username);
		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
			Username = reader.Read<string>();
		}
	}
}