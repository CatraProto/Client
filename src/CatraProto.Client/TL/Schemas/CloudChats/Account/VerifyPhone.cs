using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class VerifyPhone : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1305716726; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }

[Newtonsoft.Json.JsonProperty("phone_code_hash")]
		public string PhoneCodeHash { get; set; }

[Newtonsoft.Json.JsonProperty("phone_code")]
		public string PhoneCode { get; set; }

        
        #nullable enable
 public VerifyPhone (string phoneNumber,string phoneCodeHash,string phoneCode)
{
 PhoneNumber = phoneNumber;
PhoneCodeHash = phoneCodeHash;
PhoneCode = phoneCode;
 
}
#nullable disable
                
        internal VerifyPhone() 
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
			writer.Write(PhoneCode);

		}

		public void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			PhoneCodeHash = reader.Read<string>();
			PhoneCode = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "account.verifyPhone";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}