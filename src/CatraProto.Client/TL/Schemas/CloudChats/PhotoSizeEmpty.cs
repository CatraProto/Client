using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoSizeEmpty : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
	{


        public static int StaticConstructorId { get => 236446268; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("type")]
		public override string Type { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();

		}
	}
}