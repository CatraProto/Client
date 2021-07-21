using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class CContacts : CatraProto.Client.TL.Schemas.CloudChats.Contacts.ContactsBase
	{


        public static int StaticConstructorId { get => -353862078; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("contacts")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ContactBase> Contacts { get; set; }

[JsonPropertyName("saved_count")]
		public int SavedCount { get; set; }

[JsonPropertyName("users")]
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
	}
}