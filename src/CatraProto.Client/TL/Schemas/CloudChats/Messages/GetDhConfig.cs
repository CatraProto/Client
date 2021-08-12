using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetDhConfig : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 651135312; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(DhConfigBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("version")]
		public int Version { get; set; }

[JsonPropertyName("random_length")]
		public int RandomLength { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Version);
			writer.Write(RandomLength);

		}

		public void Deserialize(Reader reader)
		{
			Version = reader.Read<int>();
			RandomLength = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messages.getDhConfig";
		}
	}
}