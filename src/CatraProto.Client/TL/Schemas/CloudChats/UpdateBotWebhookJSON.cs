using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotWebhookJSON : UpdateBase
	{


        public static int StaticConstructorId { get => -2095595325; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("data")]
		public DataJSONBase Data { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Data = reader.Read<DataJSONBase>();
		}

		public override string ToString()
		{
			return "updateBotWebhookJSON";
		}
	}
}