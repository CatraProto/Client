using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SavedPhoneContact : SavedContactBase
	{
		public static int ConstructorId { get; } = 289586518;
		public override string Phone { get; set; }
		public override string FirstName { get; set; }
		public override string LastName { get; set; }
		public override int Date { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Phone);
			writer.Write(FirstName);
			writer.Write(LastName);
			writer.Write(Date);
		}

		public override void Deserialize(Reader reader)
		{
			Phone = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
			Date = reader.Read<int>();
		}
	}
}