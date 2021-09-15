using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserPhone : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 314130811; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("phone")]
		public string Phone { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Phone);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Phone = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "updateUserPhone";
		}
	}
}