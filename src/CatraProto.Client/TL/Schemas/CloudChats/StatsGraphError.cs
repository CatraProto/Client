using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGraphError : CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase
	{


        public static int StaticConstructorId { get => -1092839390; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("error")]
		public string Error { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Error);

		}

		public override void Deserialize(Reader reader)
		{
			Error = reader.Read<string>();

		}
	}
}