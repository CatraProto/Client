using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGroupTopPoster : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase
	{


        public static int StaticConstructorId { get => 418631927; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public override int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public override int Messages { get; set; }

[Newtonsoft.Json.JsonProperty("avg_chars")]
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
				
		public override string ToString()
		{
		    return "statsGroupTopPoster";
		}
	}
}