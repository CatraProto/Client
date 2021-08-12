using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetThemes : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 676939512; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(ThemesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("format")]
		public string Format { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Format);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Format = reader.Read<string>();
			Hash = reader.Read<int>();
		}

		public override string ToString()
		{
			return "account.getThemes";
		}
	}
}