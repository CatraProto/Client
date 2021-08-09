using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Themes : CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase
	{


        public static int StaticConstructorId { get => 2137482273; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public int Hash { get; set; }

[JsonPropertyName("Themes_")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase> Themes_ { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Themes_);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Themes_ = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();

		}
	}
}