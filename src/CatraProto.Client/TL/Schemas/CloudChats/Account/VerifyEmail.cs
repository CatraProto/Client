using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class VerifyEmail : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -323339813; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("email")]
		public string Email { get; set; }

[Newtonsoft.Json.JsonProperty("code")]
		public string Code { get; set; }

        
        #nullable enable
 public VerifyEmail (string email,string code)
{
 Email = email;
Code = code;
 
}
#nullable disable
                
        internal VerifyEmail() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Email);
			writer.Write(Code);

		}

		public void Deserialize(Reader reader)
		{
			Email = reader.Read<string>();
			Code = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "account.verifyEmail";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}