using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class AddContact : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			AddPhonePrivacyException = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -386636848; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("add_phone_privacy_exception")]
		public bool AddPhonePrivacyException { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Id { get; set; }

[Newtonsoft.Json.JsonProperty("first_name")]
		public string FirstName { get; set; }

[Newtonsoft.Json.JsonProperty("last_name")]
		public string LastName { get; set; }

[Newtonsoft.Json.JsonProperty("phone")]
		public string Phone { get; set; }


		public void UpdateFlags() 
		{
			Flags = AddPhonePrivacyException ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(FirstName);
			writer.Write(LastName);
			writer.Write(Phone);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			AddPhonePrivacyException = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();
			Phone = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "contacts.addContact";
		}
	}
}