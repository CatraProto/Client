using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class MessageStats : CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase
	{


        public static int StaticConstructorId { get => -1986399595; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("views_graph")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ViewsGraph { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ViewsGraph);

		}

		public override void Deserialize(Reader reader)
		{
			ViewsGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();

		}
				
		public override string ToString()
		{
		    return "stats.messageStats";
		}
	}
}