using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsDateRangeDays : StatsDateRangeDaysBase
	{


        public static int StaticConstructorId { get => -1237848657; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("min_date")]
		public override int MinDate { get; set; }

[JsonPropertyName("max_date")]
		public override int MaxDate { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MinDate);
			writer.Write(MaxDate);

		}

		public override void Deserialize(Reader reader)
		{
			MinDate = reader.Read<int>();
			MaxDate = reader.Read<int>();
		}

		public override string ToString()
		{
			return "statsDateRangeDays";
		}
	}
}