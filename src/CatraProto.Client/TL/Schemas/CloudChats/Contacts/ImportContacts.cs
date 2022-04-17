using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ImportContacts : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 746589157; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("contacts")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase> Contacts { get; set; }

        
        #nullable enable
 public ImportContacts (List<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase> contacts)
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

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkcontacts = 			writer.WriteVector(Contacts, false);
if(checkcontacts.IsError){
 return checkcontacts; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trycontacts = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trycontacts.IsError){
return ReadResult<IObject>.Move(trycontacts);
}
Contacts = trycontacts.Value;
return new ReadResult<IObject>(this);

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