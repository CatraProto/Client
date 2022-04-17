using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class MessageStats : CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1986399595; }
        
[Newtonsoft.Json.JsonProperty("views_graph")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ViewsGraph { get; set; }


        #nullable enable
 public MessageStats (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase viewsGraph)
{
 ViewsGraph = viewsGraph;
 
}
#nullable disable
        internal MessageStats() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkviewsGraph = 			writer.WriteObject(ViewsGraph);
if(checkviewsGraph.IsError){
 return checkviewsGraph; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryviewsGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
if(tryviewsGraph.IsError){
return ReadResult<IObject>.Move(tryviewsGraph);
}
ViewsGraph = tryviewsGraph.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "stats.messageStats";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}