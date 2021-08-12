using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextAnchor : RichTextBase
	{


        public static int StaticConstructorId { get => 894777186; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("text")]
		public RichTextBase Text { get; set; }

[JsonPropertyName("name")]
		public string Name { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Name);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<RichTextBase>();
			Name = reader.Read<string>();
		}

		public override string ToString()
		{
			return "textAnchor";
		}
	}
}