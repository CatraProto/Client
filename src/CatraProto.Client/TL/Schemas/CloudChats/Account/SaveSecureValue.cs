using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveSecureValue : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1986010339; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(SecureValueBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("value")]
		public InputSecureValueBase Value { get; set; }

[JsonPropertyName("secure_secret_id")]
		public long SecureSecretId { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Value);
			writer.Write(SecureSecretId);

		}

		public void Deserialize(Reader reader)
		{
			Value = reader.Read<InputSecureValueBase>();
			SecureSecretId = reader.Read<long>();

		}
	}
}