using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserPhone : UpdateBase
	{
		public static int ConstructorId { get; } = 314130811;
		public int UserId { get; set; }
		public string Phone { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Phone);
		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Phone = reader.Read<string>();
		}
	}
}