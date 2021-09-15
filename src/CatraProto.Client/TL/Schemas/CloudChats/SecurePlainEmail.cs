using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecurePlainEmail : CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase
	{


        public static int StaticConstructorId { get => 569137759; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("email")]
		public string Email { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Email);

		}

		public override void Deserialize(Reader reader)
		{
			Email = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "securePlainEmail";
		}
	}
}