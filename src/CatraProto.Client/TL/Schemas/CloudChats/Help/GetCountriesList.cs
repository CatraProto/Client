using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetCountriesList : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1935116200; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(CountriesListBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("lang_code")]
		public string LangCode { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
			Hash = reader.Read<int>();
		}

		public override string ToString()
		{
			return "help.getCountriesList";
		}
	}
}