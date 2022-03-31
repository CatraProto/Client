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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1913199744; }
        
[Newtonsoft.Json.JsonProperty("slug")]
		public string Slug { get; set; }


        #nullable enable
 public InputWallPaperSlug (string slug)
{
 Slug = slug;
 
}
#nullable disable
        internal InputWallPaperSlug() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}