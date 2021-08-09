using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageRange : CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase
	{


        public static int StaticConstructorId { get => 182649427; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("min_id")]
		public override int MinId { get; set; }

[JsonPropertyName("max_id")]
		public override int MaxId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MinId);
			writer.Write(MaxId);

		}

		public override void Deserialize(Reader reader)
		{
			MinId = reader.Read<int>();
			MaxId = reader.Read<int>();

		}
	}
}