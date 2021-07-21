using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonBool : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
	{


        public static int StaticConstructorId { get => -952869270; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("value")]
		public bool Value { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Value);

		}

		public override void Deserialize(Reader reader)
		{
			Value = reader.Read<bool>();

		}
	}
}