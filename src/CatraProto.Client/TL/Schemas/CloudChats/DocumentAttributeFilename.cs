using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DocumentAttributeFilename : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
	{


        public static int StaticConstructorId { get => 358154344; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("file_name")]
		public string FileName { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FileName);

		}

		public override void Deserialize(Reader reader)
		{
			FileName = reader.Read<string>();

		}
	}
}