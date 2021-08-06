using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackDifference : CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase
	{


        public static int StaticConstructorId { get => -209337866; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("lang_code")]
		public override string LangCode { get; set; }

[JsonPropertyName("from_version")]
		public override int FromVersion { get; set; }

[JsonPropertyName("version")]
		public override int Version { get; set; }

[JsonPropertyName("strings")]
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
	}
}