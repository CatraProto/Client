using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPhoneContact : CatraProto.Client.TL.Schemas.CloudChats.InputContactBase
	{


        public static int StaticConstructorId { get => -208488460; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("client_id")]
		public override long ClientId { get; set; }

[Newtonsoft.Json.JsonProperty("phone")]
		public override string Phone { get; set; }

[Newtonsoft.Json.JsonProperty("first_name")]
		public override string FirstName { get; set; }

[Newtonsoft.Json.JsonProperty("last_name")]
		public override string LastName { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ClientId);
			writer.Write(Phone);
			writer.Write(FirstName);
			writer.Write(LastName);

		}

		public override void Deserialize(Reader reader)
		{
			ClientId = reader.Read<long>();
			Phone = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "inputPhoneContact";
		}
	}
}