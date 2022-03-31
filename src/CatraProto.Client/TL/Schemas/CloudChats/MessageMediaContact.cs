using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaContact : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1882335561; }
        
[Newtonsoft.Json.JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }

[Newtonsoft.Json.JsonProperty("first_name")]
		public string FirstName { get; set; }

[Newtonsoft.Json.JsonProperty("last_name")]
		public string LastName { get; set; }

[Newtonsoft.Json.JsonProperty("vcard")]
		public string Vcard { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }


        #nullable enable
 public MessageMediaContact (string phoneNumber,string firstName,string lastName,string vcard,long userId)
{
 PhoneNumber = phoneNumber;
FirstName = firstName;
LastName = lastName;
Vcard = vcard;
UserId = userId;
 
}
#nullable disable
        internal MessageMediaContact() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PhoneNumber);
			writer.Write(FirstName);
			writer.Write(LastName);
			writer.Write(Vcard);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
			Vcard = reader.Read<string>();
			UserId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messageMediaContact";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}