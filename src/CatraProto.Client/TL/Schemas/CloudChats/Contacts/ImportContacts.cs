using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ImportContacts : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportedContactsBase>
	{


        public static int ConstructorId { get; } = 746589157;

		public IList<InputContactBase> Contacts { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Contacts);

		}

		public void Deserialize(Reader reader)
		{
			Contacts = reader.ReadVector<InputContactBase>();

		}
	}
}