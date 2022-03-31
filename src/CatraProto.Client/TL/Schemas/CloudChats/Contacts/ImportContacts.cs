using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ImportContacts : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 746589157; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportedContactsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("contacts")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase> Contacts { get; set; }

        
        #nullable enable
 public ImportContacts (IList<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase> contacts)
{
 Contacts = contacts;
 
}
#nullable disable
                
        internal ImportContacts() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Contacts);

		}

		public void Deserialize(Reader reader)
		{
			Contacts = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase>();

		}

		public override string ToString()
		{
		    return "contacts.importContacts";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}