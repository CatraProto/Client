using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class RequestEncryption : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -162681021; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[JsonPropertyName("random_id")]
		public int RandomId { get; set; }

[JsonPropertyName("g_a")]
		public byte[] GA { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(RandomId);
			writer.Write(GA);

		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			RandomId = reader.Read<int>();
			GA = reader.Read<byte[]>();

		}
	}
}