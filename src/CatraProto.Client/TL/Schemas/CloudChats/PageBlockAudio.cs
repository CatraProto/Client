using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockAudio : PageBlockBase
	{


        public static int StaticConstructorId { get => -2143067670; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("audio_id")]
		public long AudioId { get; set; }

[JsonPropertyName("caption")]
		public PageCaptionBase Caption { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(AudioId);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			AudioId = reader.Read<long>();
			Caption = reader.Read<PageCaptionBase>();

		}
	}
}