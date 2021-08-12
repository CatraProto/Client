using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockMap : PageBlockBase
	{


        public static int StaticConstructorId { get => -1538310410; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("geo")]
		public GeoPointBase Geo { get; set; }

[JsonPropertyName("zoom")]
		public int Zoom { get; set; }

[JsonPropertyName("w")]
		public int W { get; set; }

[JsonPropertyName("h")]
		public int H { get; set; }

[JsonPropertyName("caption")]
		public PageCaptionBase Caption { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Geo);
			writer.Write(Zoom);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Geo = reader.Read<GeoPointBase>();
			Zoom = reader.Read<int>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Caption = reader.Read<PageCaptionBase>();
		}

		public override string ToString()
		{
			return "pageBlockMap";
		}
	}
}