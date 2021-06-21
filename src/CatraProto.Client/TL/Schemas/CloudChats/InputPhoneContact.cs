using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPhoneContact : InputContactBase
	{
		public static int ConstructorId { get; } = -208488460;
		public override long ClientId { get; set; }
		public override string Phone { get; set; }
		public override string FirstName { get; set; }
		public override string LastName { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ClientId);
			writer.Write(Phone);
			writer.Write(FirstName);
			writer.Write(LastName);
		}

		public override void Deserialize(Reader reader)
		{
			ClientId = reader.Read<long>();
			Phone = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
		}
	}
}