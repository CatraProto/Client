using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class CContacts : ContactsBase
	{
		public static int ConstructorId { get; } = -353862078;
		public IList<ContactBase> Contacts { get; set; }
		public int SavedCount { get; set; }
		public IList<UserBase> Users { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Contacts);
			writer.Write(SavedCount);
			writer.Write(Users);
		}

		public override void Deserialize(Reader reader)
		{
			Contacts = reader.ReadVector<ContactBase>();
			SavedCount = reader.Read<int>();
			Users = reader.ReadVector<UserBase>();
		}
	}
}