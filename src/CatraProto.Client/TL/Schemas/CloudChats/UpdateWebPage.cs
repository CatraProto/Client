using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateWebPage : UpdateBase
	{


        public static int StaticConstructorId { get => 2139689491; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("webpage")]
		public WebPageBase Webpage { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public int PtsCount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Webpage);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Webpage = reader.Read<WebPageBase>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
		}

		public override string ToString()
		{
			return "updateWebPage";
		}
	}
}