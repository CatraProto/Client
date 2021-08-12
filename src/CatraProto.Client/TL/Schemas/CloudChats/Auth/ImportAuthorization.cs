using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ImportAuthorization : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -470837741; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(AuthorizationBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("id")]
		public int Id { get; set; }

[JsonPropertyName("bytes")]
		public byte[] Bytes { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Bytes);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			Bytes = reader.Read<byte[]>();
		}

		public override string ToString()
		{
			return "auth.importAuthorization";
		}
	}
}