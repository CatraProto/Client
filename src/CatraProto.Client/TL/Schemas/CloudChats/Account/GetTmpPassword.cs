using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetTmpPassword : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1151208273; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(TmpPasswordBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("password")]
		public InputCheckPasswordSRPBase Password { get; set; }

[JsonPropertyName("period")]
		public int Period { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Password);
			writer.Write(Period);

		}

		public void Deserialize(Reader reader)
		{
			Password = reader.Read<InputCheckPasswordSRPBase>();
			Period = reader.Read<int>();
		}

		public override string ToString()
		{
			return "account.getTmpPassword";
		}
	}
}