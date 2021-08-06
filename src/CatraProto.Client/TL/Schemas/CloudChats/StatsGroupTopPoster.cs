using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGroupTopPoster : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase
	{


        public static int StaticConstructorId { get => 418631927; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("messages")]
		public override int Messages { get; set; }

[JsonPropertyName("avg_chars")]
		public override int AvgChars { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Messages);
			writer.Write(AvgChars);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Messages = reader.Read<int>();
			AvgChars = reader.Read<int>();

		}
	}
}