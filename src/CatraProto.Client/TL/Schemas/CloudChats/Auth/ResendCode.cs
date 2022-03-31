using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ResendCode : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1056025023; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }

[Newtonsoft.Json.JsonProperty("phone_code_hash")]
		public string PhoneCodeHash { get; set; }

        
        #nullable enable
 public ResendCode (string phoneNumber,string phoneCodeHash)
{
 PhoneNumber = phoneNumber;
PhoneCodeHash = phoneCodeHash;
 
}
#nullable disable
                
        internal ResendCode() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PhoneNumber);
			writer.Write(PhoneCodeHash);

		}

		public void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			PhoneCodeHash = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "auth.resendCode";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}