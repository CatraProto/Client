using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputWallPaperSlug : CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase
	{


        public static int StaticConstructorId { get => 1913199744; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("slug")]
		public string Slug { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Slug);

		}

		public override void Deserialize(Reader reader)
		{
			Slug = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "inputWallPaperSlug";
		}
	}
}