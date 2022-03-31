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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -209337866; }
        
[Newtonsoft.Json.JsonProperty("lang_code")]
		public sealed override string LangCode { get; set; }

[Newtonsoft.Json.JsonProperty("from_version")]
		public sealed override int FromVersion { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public sealed override int Version { get; set; }

[Newtonsoft.Json.JsonProperty("strings")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase> Strings { get; set; }


        #nullable enable
 public LangPackDifference (string langCode,int fromVersion,int version,IList<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase> strings)
{
 LangCode = langCode;
FromVersion = fromVersion;
Version = version;
Strings = strings;
 
}
#nullable disable
        internal LangPackDifference() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}