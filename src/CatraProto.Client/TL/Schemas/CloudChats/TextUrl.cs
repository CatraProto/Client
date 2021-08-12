using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextUrl : RichTextBase
	{


        public static int StaticConstructorId { get => 1009288385; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("text")]
		public RichTextBase Text { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

[JsonPropertyName("webpage_id")]
		public long WebpageId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Url);
			writer.Write(WebpageId);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<RichTextBase>();
			Url = reader.Read<string>();
			WebpageId = reader.Read<long>();
		}

		public override string ToString()
		{
			return "textUrl";
		}
	}
}