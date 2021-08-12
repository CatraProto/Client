using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ImportContacts : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 746589157; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(ImportedContactsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("contacts")]
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

		public override string ToString()
		{
			return "contacts.importContacts";
		}
	}
}