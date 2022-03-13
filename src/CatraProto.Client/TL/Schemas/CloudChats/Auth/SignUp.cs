using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SignUp : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -2131827673; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }

[Newtonsoft.Json.JsonProperty("phone_code_hash")]
		public string PhoneCodeHash { get; set; }

[Newtonsoft.Json.JsonProperty("first_name")]
		public string FirstName { get; set; }

[Newtonsoft.Json.JsonProperty("last_name")]
		public string LastName { get; set; }

        
        #nullable enable
 public SignUp (string phoneNumber,string phoneCodeHash,string firstName,string lastName)
{
 PhoneNumber = phoneNumber;
PhoneCodeHash = phoneCodeHash;
FirstName = firstName;
LastName = lastName;
 
}
#nullable disable
                
        internal SignUp() 
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
			writer.Write(FirstName);
			writer.Write(LastName);

		}

		public void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			PhoneCodeHash = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "auth.signUp";
		}
	}
}