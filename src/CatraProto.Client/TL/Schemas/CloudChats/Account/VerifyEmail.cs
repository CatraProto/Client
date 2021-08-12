using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class VerifyEmail : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -323339813; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("email")]
		public string Email { get; set; }

[JsonPropertyName("code")]
		public string Code { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}