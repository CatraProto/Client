using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebPagePending : WebPageBase
	{


        public static int StaticConstructorId { get => -981018084; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public long Id { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Date = reader.Read<int>();
		}

		public override string ToString()
		{
			return "webPagePending";
		}
	}
}