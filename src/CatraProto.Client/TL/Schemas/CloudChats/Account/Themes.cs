using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Themes : CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase
	{


        public static int StaticConstructorId { get => -1707242387; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("themes")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase> ThemesField { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(ThemesField);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<long>();
			ThemesField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();

		}
				
		public override string ToString()
		{
		    return "account.themes";
		}
	}
}