using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ContactsNotModified : ContactsBase
	{


        public static int StaticConstructorId { get => -1219778094; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{
		}

		public override string ToString()
		{
			return "contacts.contactsNotModified";
		}
	}
}