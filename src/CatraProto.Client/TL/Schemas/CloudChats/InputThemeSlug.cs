using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputThemeSlug : CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase
	{


        public static int StaticConstructorId { get => -175567375; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("slug")]
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
	}
}