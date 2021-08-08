using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaWebPage : MessageMediaBase
	{


        public static int StaticConstructorId { get => -1557277184; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("webpage")]
		public WebPageBase Webpage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Webpage);

		}

		public override void Deserialize(Reader reader)
		{
			Webpage = reader.Read<WebPageBase>();

		}
	}
}