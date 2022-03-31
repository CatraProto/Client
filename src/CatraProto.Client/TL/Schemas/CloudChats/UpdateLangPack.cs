using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateLangPack : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1442983757; }
        
[Newtonsoft.Json.JsonProperty("difference")]
		public CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase Difference { get; set; }


        #nullable enable
 public UpdateLangPack (CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase difference)
{
 Difference = difference;
 
}
#nullable disable
        internal UpdateLangPack() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Difference);

		}

		public override void Deserialize(Reader reader)
		{
			Difference = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>();

		}
		
		public override string ToString()
		{
		    return "updateLangPack";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}