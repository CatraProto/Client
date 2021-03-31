using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class GetContacts : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Contacts.ContactsBase>
	{


        public static int ConstructorId { get; } = -1071414113;

		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();

		}
	}
}