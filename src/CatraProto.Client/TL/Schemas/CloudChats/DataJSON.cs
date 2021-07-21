using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DataJSON : CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase
	{


        public static int StaticConstructorId { get => 2104790276; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("data")]
		public override string Data { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Data = reader.Read<string>();

		}
	}
}