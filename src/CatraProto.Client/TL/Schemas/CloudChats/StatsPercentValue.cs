using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsPercentValue : StatsPercentValueBase
	{


        public static int StaticConstructorId { get => -875679776; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("part")]
		public override double Part { get; set; }

[JsonPropertyName("total")]
		public override double Total { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Part);
			writer.Write(Total);

		}

		public override void Deserialize(Reader reader)
		{
			Part = reader.Read<double>();
			Total = reader.Read<double>();
		}

		public override string ToString()
		{
			return "statsPercentValue";
		}
	}
}