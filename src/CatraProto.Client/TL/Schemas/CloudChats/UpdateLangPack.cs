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


        public static int StaticConstructorId { get => 1442983757; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("difference")]
		public CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase Difference { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}