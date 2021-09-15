using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SavedPhoneContact : CatraProto.Client.TL.Schemas.CloudChats.SavedContactBase
	{


        public static int StaticConstructorId { get => 289586518; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("phone")]
		public override string Phone { get; set; }

[Newtonsoft.Json.JsonProperty("first_name")]
		public override string FirstName { get; set; }

[Newtonsoft.Json.JsonProperty("last_name")]
		public override string LastName { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public override int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Phone);
			writer.Write(FirstName);
			writer.Write(LastName);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Phone = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
			Date = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "savedPhoneContact";
		}
	}
}