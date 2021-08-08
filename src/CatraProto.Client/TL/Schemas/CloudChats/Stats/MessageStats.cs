using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class MessageStats : MessageStatsBase
	{


        public static int StaticConstructorId { get => -1986399595; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("views_graph")]
		public override StatsGraphBase ViewsGraph { get; set; }

        
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
			ViewsGraph = reader.Read<StatsGraphBase>();

		}
	}
}