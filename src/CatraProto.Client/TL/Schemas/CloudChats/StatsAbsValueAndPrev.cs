using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsAbsValueAndPrev : StatsAbsValueAndPrevBase
	{


        public static int StaticConstructorId { get => -884757282; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("current")]
		public override double Current { get; set; }

[JsonPropertyName("previous")]
		public override double Previous { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Current);
			writer.Write(Previous);

		}

		public override void Deserialize(Reader reader)
		{
			Current = reader.Read<double>();
			Previous = reader.Read<double>();
		}

		public override string ToString()
		{
			return "statsAbsValueAndPrev";
		}
	}
}