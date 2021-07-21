using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DocumentAttributeImageSize : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
	{


        public static int StaticConstructorId { get => 1815593308; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("w")]
		public int W { get; set; }

[JsonPropertyName("h")]
		public int H { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(W);
			writer.Write(H);

		}

		public override void Deserialize(Reader reader)
		{
			W = reader.Read<int>();
			H = reader.Read<int>();

		}
	}
}