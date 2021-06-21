using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ImportedContacts : ImportedContactsBase
	{


        public static int ConstructorId { get; } = 2010127419;
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase> Imported { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase> PopularInvites { get; set; }
		public override IList<long> RetryContacts { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Imported);
			writer.Write(PopularInvites);
			writer.Write(RetryContacts);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Imported = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase>();
			PopularInvites = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase>();
			RetryContacts = reader.ReadVector<long>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}