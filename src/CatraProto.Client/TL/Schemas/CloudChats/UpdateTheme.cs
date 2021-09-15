using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateTheme : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -2112423005; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("theme")]
		public CatraProto.Client.TL.Schemas.CloudChats.ThemeBase Theme { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Theme);

		}

		public override void Deserialize(Reader reader)
		{
			Theme = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();

		}
				
		public override string ToString()
		{
		    return "updateTheme";
		}
	}
}