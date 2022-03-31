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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 569137759; }
        
[Newtonsoft.Json.JsonProperty("email")]
		public string Email { get; set; }


        #nullable enable
 public SecurePlainEmail (string email)
{
 Email = email;
 
}
#nullable disable
        internal SecurePlainEmail() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}