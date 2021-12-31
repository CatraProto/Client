using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ApiContacts : CatraProto.Client.TL.Schemas.CloudChats.Contacts.ContactsBase
	{


        public static int StaticConstructorId { get => -353862078; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("contacts")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ContactBase> Contacts { get; set; }

[Newtonsoft.Json.JsonProperty("saved_count")]
		public int SavedCount { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Contacts);
			writer.Write(SavedCount);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Contacts = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ContactBase>();
			SavedCount = reader.Read<int>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "contacts.contacts";
		}
	}
}