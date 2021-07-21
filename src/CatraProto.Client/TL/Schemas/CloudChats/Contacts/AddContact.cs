using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class AddContact : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			AddPhonePrivacyException = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -386636848; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("add_phone_privacy_exception")]
		public bool AddPhonePrivacyException { get; set; }

[JsonPropertyName("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Id { get; set; }

[JsonPropertyName("first_name")]
		public string FirstName { get; set; }

[JsonPropertyName("last_name")]
		public string LastName { get; set; }

[JsonPropertyName("phone")]
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
	}
}