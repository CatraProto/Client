using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackDifference : CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase
	{


        public static int StaticConstructorId { get => -209337866; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("lang_code")]
		public override string LangCode { get; set; }

[Newtonsoft.Json.JsonProperty("from_version")]
		public override int FromVersion { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public override int Version { get; set; }

[Newtonsoft.Json.JsonProperty("strings")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase> Strings { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);
			writer.Write(FromVersion);
			writer.Write(Version);
			writer.Write(Strings);

		}

		public override void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
			FromVersion = reader.Read<int>();
			Version = reader.Read<int>();
			Strings = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>();

		}
				
		public override string ToString()
		{
		    return "langPackDifference";
		}
	}
}