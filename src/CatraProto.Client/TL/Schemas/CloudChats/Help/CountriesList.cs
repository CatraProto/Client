using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class CountriesList : CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListBase
	{


        public static int StaticConstructorId { get => -2016381538; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("countries")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase> Countries { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public int Hash { get; set; }


        #nullable enable
 public CountriesList (IList<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase> countries,int hash)
{
 Countries = countries;
Hash = hash;
 
}
#nullable disable
        internal CountriesList() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Countries);
			writer.Write(Hash);

		}

		public override void Deserialize(Reader reader)
		{
			Countries = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase>();
			Hash = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "help.countriesList";
		}
	}
}