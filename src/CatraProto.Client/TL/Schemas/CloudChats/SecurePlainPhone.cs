using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecurePlainPhone : CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase
	{


        public static int StaticConstructorId { get => 2103482845; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("phone")]
		public string Phone { get; set; }


        #nullable enable
 public SecurePlainPhone (string phone)
{
 Phone = phone;
 
}
#nullable disable
        internal SecurePlainPhone() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Phone);

		}

		public override void Deserialize(Reader reader)
		{
			Phone = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "securePlainPhone";
		}
	}
}