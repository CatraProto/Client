using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SignIn : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1126886015; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(AuthorizationBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("phone_number")]
		public string PhoneNumber { get; set; }

[JsonPropertyName("phone_code_hash")]
		public string PhoneCodeHash { get; set; }

[JsonPropertyName("phone_code")]
		public string PhoneCode { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
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
			return "auth.signIn";
		}
	}
}