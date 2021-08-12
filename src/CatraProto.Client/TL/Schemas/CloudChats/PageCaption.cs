using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageCaption : PageCaptionBase
	{


        public static int StaticConstructorId { get => 1869903447; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("text")]
		public override RichTextBase Text { get; set; }

[JsonPropertyName("credit")]
		public override RichTextBase Credit { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Credit);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<RichTextBase>();
			Credit = reader.Read<RichTextBase>();
		}

		public override string ToString()
		{
			return "pageCaption";
		}
	}
}