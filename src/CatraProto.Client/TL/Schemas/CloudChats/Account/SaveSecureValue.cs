using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveSecureValue : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1986010339; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("value")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase Value { get; set; }

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
			Value = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase>();
			SecureSecretId = reader.Read<long>();

		}
	}
}