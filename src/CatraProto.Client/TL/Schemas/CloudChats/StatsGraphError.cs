using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGraphError : StatsGraphBase
	{


        public static int StaticConstructorId { get => -1092839390; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("error")]
		public string Error { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Error);

		}

		public override void Deserialize(Reader reader)
		{
			Error = reader.Read<string>();
		}

		public override string ToString()
		{
			return "statsGraphError";
		}
	}
}