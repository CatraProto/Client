using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockPreformatted : PageBlockBase
	{


        public static int StaticConstructorId { get => -1066346178; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("text")]
		public RichTextBase Text { get; set; }

[JsonPropertyName("language")]
		public string Language { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Language);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<RichTextBase>();
			Language = reader.Read<string>();
		}

		public override string ToString()
		{
			return "pageBlockPreformatted";
		}
	}
}