using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class PassportConfig : CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase
	{


        public static int StaticConstructorId { get => -1600596305; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public int Hash { get; set; }

[JsonPropertyName("countries_langs")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase CountriesLangs { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(CountriesLangs);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			CountriesLangs = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
	}
}