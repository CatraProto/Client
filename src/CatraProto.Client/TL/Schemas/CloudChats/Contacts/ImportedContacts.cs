using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ImportedContacts : CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportedContactsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2010127419; }
        
[Newtonsoft.Json.JsonProperty("imported")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase> Imported { get; set; }

[Newtonsoft.Json.JsonProperty("popular_invites")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase> PopularInvites { get; set; }

[Newtonsoft.Json.JsonProperty("retry_contacts")]
		public sealed override IList<long> RetryContacts { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ImportedContacts (IList<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase> imported,IList<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase> popularInvites,IList<long> retryContacts,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Imported = imported;
PopularInvites = popularInvites;
RetryContacts = retryContacts;
Users = users;
 
}
#nullable disable
        internal ImportedContacts() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
		
		public override string ToString()
		{
		    return "contacts.importedContacts";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}