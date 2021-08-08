using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class DifferenceEmpty : DifferenceBase
	{


        public static int StaticConstructorId { get => 1567990072; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("seq")]
		public int Seq { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Date);
			writer.Write(Seq);

		}

		public override void Deserialize(Reader reader)
		{
			Date = reader.Read<int>();
			Seq = reader.Read<int>();

		}
	}
}