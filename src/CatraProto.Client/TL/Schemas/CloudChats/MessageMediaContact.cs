using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaContact : MessageMediaBase
	{
		public static int ConstructorId { get; } = -873313984;
		public string PhoneNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Vcard { get; set; }
		public int UserId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(PhoneNumber);
			writer.Write(FirstName);
			writer.Write(LastName);
			writer.Write(Vcard);
			writer.Write(UserId);
		}

		public override void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
			Vcard = reader.Read<string>();
			UserId = reader.Read<int>();
		}
	}
}