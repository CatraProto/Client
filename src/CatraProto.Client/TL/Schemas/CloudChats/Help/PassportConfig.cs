using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class PassportConfig : CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1600596305; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public int Hash { get; set; }

[Newtonsoft.Json.JsonProperty("countries_langs")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase CountriesLangs { get; set; }


        #nullable enable
 public PassportConfig (int hash,CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase countriesLangs)
{
 Hash = hash;
CountriesLangs = countriesLangs;
 
}
#nullable disable
        internal PassportConfig() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(CountriesLangs);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			CountriesLangs = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
		
		public override string ToString()
		{
		    return "help.passportConfig";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}