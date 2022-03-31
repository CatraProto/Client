using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SendVerifyEmailCode : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1880182943; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("email")]
		public string Email { get; set; }

        
        #nullable enable
 public SendVerifyEmailCode (string email)
{
 Email = email;
 
}
#nullable disable
                
        internal SendVerifyEmailCode() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Email);

		}

		public void Deserialize(Reader reader)
		{
			Email = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "account.sendVerifyEmailCode";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}