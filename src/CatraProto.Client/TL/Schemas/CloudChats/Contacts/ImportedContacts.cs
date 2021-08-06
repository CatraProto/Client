using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ImportedContacts : CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportedContactsBase
	{


        public static int StaticConstructorId { get => 2010127419; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("imported")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase> Imported { get; set; }

[JsonPropertyName("popular_invites")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase> PopularInvites { get; set; }

[JsonPropertyName("retry_contacts")]
		public override IList<long> RetryContacts { get; set; }

[JsonPropertyName("users")]
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