using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGraphAsync : StatsGraphBase
	{


        public static int StaticConstructorId { get => 1244130093; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("token")]
		public string Token { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Token);

		}

		public override void Deserialize(Reader reader)
		{
			Token = reader.Read<string>();

		}
	}
}